using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace JSCNSercurity { 
    public static class Sercurity
    {
        /// <summary>
        /// Base 64
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public static string Base64(string input)
        {
            byte[] encodedBytes;

            using (var md5 = new MD5CryptoServiceProvider())
            {
                var originalBytes = Encoding.Default.GetBytes(input);
                encodedBytes = md5.ComputeHash(originalBytes);
            }

            return Convert.ToBase64String(encodedBytes);
        }
        /// <summary>
        /// Mã hoá MD5
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string MD5(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
        public static string PMD5(this string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
   
    }
}