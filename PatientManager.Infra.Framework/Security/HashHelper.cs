using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace PatientManager.Infra.Framework.Security
{
    public class HashHelper
    {
        public static string Encrypt(string strText)
        {
            byte[] byteHash;
            byte[] byteBuff;
            string encoded = null;

            if (!string.IsNullOrEmpty(strText))
            {
                TripleDESCryptoServiceProvider desCryptoProvider = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider();

                byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["hashKey"]));
                desCryptoProvider.Key = byteHash;
                desCryptoProvider.Mode = CipherMode.ECB; //CBC, CFB
                byteBuff = Encoding.UTF8.GetBytes(strText);

                encoded = Convert.ToBase64String(desCryptoProvider.CreateEncryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
            }

            return encoded;
        }

        public static string Decrypt(string encodedText)
        {
            TripleDESCryptoServiceProvider desCryptoProvider = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider();

            byte[] byteHash;
            byte[] byteBuff;

            byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["hashKey"]));
            desCryptoProvider.Key = byteHash;
            desCryptoProvider.Mode = CipherMode.ECB; //CBC, CFB
            byteBuff = Convert.FromBase64String(encodedText);

            string plaintext = Encoding.UTF8.GetString(desCryptoProvider.CreateDecryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
            return plaintext;
        }
    }
}
