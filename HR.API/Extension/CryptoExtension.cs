using System;
using System.Security.Cryptography;
using System.Text;

namespace HR.API
{
    public static class CryptoExtension
    {
        public static string ToSHA1(this string value)
        {
            using (var crypt = new SHA1Managed())
            {
                return BitConverter.ToString(crypt.ComputeHash(Encoding.UTF8.GetBytes(value))).Replace("-", string.Empty);
            }
        }

        public static string ToSHA256(this string value)
        {
            using (var crypt = new SHA256Managed())
            {
                var hash = new StringBuilder();
                byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(value), 0, Encoding.UTF8.GetByteCount(value));
                foreach (byte bytex in crypto)
                    hash.Append(bytex.ToString("x2"));

                return hash.ToString();
            }
        }
    }
}