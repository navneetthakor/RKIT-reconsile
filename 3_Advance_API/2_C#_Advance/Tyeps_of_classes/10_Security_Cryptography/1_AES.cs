﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceAPI.Security_Cryptography.AES
{
    internal class Tester
    {
        public static void TestNow()
        {
            // Create a 16-byte (128-bit) key using RandomNumberGenerator
            byte[] key = new byte[16];
            byte[] iv = new byte[16]; // CBC mode
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                // Fill the byte array with random values
                rng.GetBytes(key); 
                rng.GetBytes(iv);
            }
            string encrpytedStr = Tester.Encrypt("Hello RKIT TEAM", key, iv);
            Console.WriteLine(encrpytedStr);
            Console.WriteLine(Tester.Decrypt(encrpytedStr, key, iv));
        }

        // Encrypts the plaintext using AES algorithm
        private static string Encrypt(string plainText, byte[] key, byte[] iv)
        {
            string encString = "";
            using (Aes aes = Aes.Create())
            {
                //initializing required structure 
                aes.Key = key;
                aes.IV = iv;

                //creating encryptor 
                ICryptoTransform encriptor = aes.CreateEncryptor();


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

            using (Aes aes = Aes.Create())
            {
                //initializing required structure 
                aes.Key = key;
                aes.IV = iv;

                //creating encryptor 
                ICryptoTransform decriptor = aes.CreateDecryptor();

                using (MemoryStream mst = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using(CryptoStream cst = new CryptoStream(mst,decriptor, CryptoStreamMode.Read))
                    {
                        using(StreamReader sr = new StreamReader(cst))
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
