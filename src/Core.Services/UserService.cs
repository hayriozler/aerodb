using System;
using AeroDb.Core.Security;

namespace Core.Services
{
    public class UserService : IUserService
    {
        public UserService()
        {
        }
        public bool VerifyPassword(string password, string hash, string salt)
        {
            var passwordArray = Convert.FromBase64String(password);
            return Hasher.VerifyHashSHA512(passwordArray,
                      Convert.FromBase64String(hash),
                      Convert.FromBase64String(salt));
        }
    }
}
