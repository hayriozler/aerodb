using System;

namespace Core.Domain.Users
{
    public class UserToken
    {
        public string Token { get; set; }
        public DateTime ExpiryDateTime { get; set; }
    }
}
