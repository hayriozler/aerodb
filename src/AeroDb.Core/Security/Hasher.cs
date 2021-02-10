using System;
using System.Security.Cryptography;
using System.Text;

namespace AeroDb.Core.Security
{
    public static class Hasher
    {
        public static HashResult CreateHashSHA512(string text)
        {
            var result = new HashResult();
            using (var hmac = new HMACSHA512())
            {
                result.Salt = Convert.ToBase64String(hmac.Key);
                result.Hash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(text)));
            }
            return result;
        }

        public static bool IsBase64(string base64String)
        {
            if (base64String == null) throw new ArgumentNullException(base64String);
            Span<byte> buffer = new Span<byte>(new byte[base64String.Length]);
            return Convert.TryFromBase64String(base64String, buffer, out _);
        }
        public static bool VerifyHashSHA512(byte[] passText, byte[] storedHash, byte[] storedSalt)
        {
            if (passText == null) throw new ArgumentNullException(nameof(passText));
            if (storedHash == null) throw new ArgumentNullException(nameof(storedHash));
            if (storedSalt == null) throw new ArgumentNullException(nameof(storedSalt));

            using (var hmac = new HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(passText);
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }
            return true;
        }
    }
}
