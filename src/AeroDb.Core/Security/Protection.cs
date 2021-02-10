using System;
using System.IO;
using System.Security.Cryptography;

namespace AeroDb.Core.Security
{
    public static class Protection
    {
        private static string _goldenKey = "dmVyeSFjb21wbGV4QEtleSEhc2hvdWxkXmNvbWVIZXI=";
        private static string _iv = "dk5leHQtQXBwbGljYXRpbw==";//at least 16 bytes
        private static byte[] GetKey()
        {
            return Convert.FromBase64String(_goldenKey);
        }
        private static byte[] GetIv()
        {
            return Convert.FromBase64String(_iv);
        }
        public static string Protect(string value)
        {
            byte[] encrypted;
            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = GetKey();
                aesAlg.IV = GetIv();
                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using var msEncrypt = new MemoryStream();
                using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
                using (var swEncrypt = new StreamWriter(csEncrypt))
                    swEncrypt.Write(value);
                encrypted = msEncrypt.ToArray();
            }
            return Convert.ToBase64String(encrypted);
        }
        public static string Unprotect(string value)
        {
            string plaintext;
            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = GetKey();
                aesAlg.IV = GetIv();
                byte[] cipherText = Convert.FromBase64String(value);
                var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using var msDecrypt = new MemoryStream(cipherText);
                using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
                using var srDecrypt = new StreamReader(csDecrypt);
                plaintext = srDecrypt.ReadToEnd();
            }
            return plaintext;
        }
        public static string GenerateApiKey()
        {
            var key = new byte[64];
            using (var generator = RandomNumberGenerator.Create())
                generator.GetBytes(key);
            return Convert.ToBase64String(key);
        }
    }
}
