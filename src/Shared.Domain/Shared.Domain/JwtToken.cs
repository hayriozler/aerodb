using System;
using System.IdentityModel.Tokens.Jwt;

namespace Core.Domain
{
    public class JwtToken
    {
        private JwtSecurityToken token;

        public JwtToken(JwtSecurityToken token)
        {
            this.token = token;
        }

        public DateTime ValidTo => token.ValidTo;
        public string Value => new JwtSecurityTokenHandler().WriteToken(this.token);
    }

    public class GenereatedToken
    {
        public string Token { get; set; }
        public DateTime ExpirationDateTime { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshExpirationDateTime { get; set; }
    }
}
