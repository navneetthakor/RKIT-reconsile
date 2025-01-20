using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceAPI.Security_Cryptography.RsaAlgo
{
    internal class Tester
    {
        public static void TestNow()
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider()) 
            {
                //creating public and private key 
                string publicKey = rsa.ToXmlString(false);
                string privateKey = rsa.ToXmlString(true);


                string encString = Encrypt(publicKey, "Hello RKIT Team");
                Console.WriteLine(encString);


                Console.WriteLine(rsa.Decrypt(Encoding.UTF8.GetBytes(encString),true));
            }

        }
        private static string Encrypt(string publicKey, string plainText)
        {
                using(RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(publicKey);
                    return Convert.ToBase64String(rsa.Encrypt(Encoding.UTF8.GetBytes(plainText),true));

                }
        }

    }
}
