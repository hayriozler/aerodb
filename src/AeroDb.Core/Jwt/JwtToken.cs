using System;
using System.IdentityModel.Tokens.Jwt;

namespace AeroDb.Core.Jwt
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
}
