using System;
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

        }

        // Encrypts the plaintext using AES algorithm
        public static string Encrypt(string plainText, string key)
        {
            using(Aes aes = Aes.Create()) 
            {
                //initializing required structure 
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.GenerateIV();


            }
            


            return "";
        }

        // Decrypts the encrypted text using AES algorithm
        public static string Decrypt(string cipherText, string key)
        {


            return "";
        }
    }
}
