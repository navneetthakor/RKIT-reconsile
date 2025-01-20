using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace AdvanceAPI.Security_Cryptography.DesAlgo
{
    internal class Tester
    {
        public static void TestNow()
        {
            
           
            using (DES outerDes = DES.Create())
            {
                outerDes.GenerateKey();
                outerDes.GenerateIV();
            string encrpytedStr = Tester.Encrypt("Hello RKIT TEAM", outerDes.Key, outerDes.IV);
            Console.WriteLine(encrpytedStr);
            Console.WriteLine(Tester.Decrypt(encrpytedStr, outerDes.Key, outerDes.IV));
            }
        }

        // Encrypts the plaintext using DES algorithm
        private static string Encrypt(string plainText, byte[] key, byte[] iv)
        {
            string encString = "";
            using (DES des = DES.Create())
            {
                //initializing required structure 
                des.Key = key;
                des.IV = iv;

                //creating encryptor 
                ICryptoTransform encriptor = des.CreateEncryptor();


                // cryptostream requirs undrlying stream to write encrited data
                // therefore here we choosed MemoryStream (writes data in main memory itself)
                using (MemoryStream mst = new MemoryStream())
                {
                    // cryptostream is stream class of using 'System.Security.Cryptography' namespace
                    // this is necessory for encripting data
                    using (CryptoStream cst = new CryptoStream(mst, encriptor, CryptoStreamMode.Write))
                    {

                        // writing data in CyptoStream
                        // further cryptostream encrpt the data and then writes in undrlaying stream
                        using (StreamWriter sw = new StreamWriter(cst))
                        {
                            sw.Write(plainText);
                        }
                    }

                    // writing encrypted data
                    encString = Convert.ToBase64String(mst.ToArray());
                }


            }

            return encString;
        }

        // Decrypts the encrypted text using AES algorithm
        private static string Decrypt(string cipherText, byte[] key, byte[] iv)
        {
            string plainText = "";

            using (DES des = DES.Create())
            {
                //initializing required structure 
                des.Key = key;
                des.IV = iv;

                //creating encryptor 
                ICryptoTransform decriptor = des.CreateDecryptor();

                using (MemoryStream mst = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (CryptoStream cst = new CryptoStream(mst, decriptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cst))
                        {
                            plainText = sr.ReadToEnd();
                        }
                    }
                }


                return plainText;
            }

        }
    }
}
