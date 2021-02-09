using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Core.Domain;
using Microsoft.IdentityModel.Tokens;

namespace AeroDb.Core.Jwt
{
    public class JwtTokenBuilder
    {
        private SecurityKey _securityKey = null;
        private bool _useissuer;
        private string _issuer = "";
        private bool _useaudience;
        private string _audience = "";
        private Dictionary<string, string> _claims = new Dictionary<string, string>();
        private int _expiryInMinutes = 5;

        private void EnsureArguments()
        {
            if (_securityKey == null)
                throw new ArgumentNullException("Security Key");

            if (_useissuer && string.IsNullOrEmpty(_issuer))
                throw new ArgumentNullException("Issuer");

            if (_useaudience && string.IsNullOrEmpty(_audience))
                throw new ArgumentNullException("Audience");
        }

        public JwtTokenBuilder AddSecurityKey(SecurityKey securityKey)
        {
            _securityKey = securityKey;
            return this;
        }

        public JwtTokenBuilder AddIssuer(string issuer)
        {
            _issuer = issuer;
            _useissuer = true;
            return this;
        }

        public JwtTokenBuilder AddAudience(string audience)
        {
            _audience = audience;
            _useaudience = true;
            return this;
        }

        public JwtTokenBuilder AddClaim(string type, string value)
        {
            _claims.Add(type, value);
            return this;
        }

        public JwtTokenBuilder AddClaims(Dictionary<string, string> claims)
        {
            foreach (var item in claims)
            {
                if (!_claims.ContainsKey(item.Key) && !string.IsNullOrEmpty(item.Value))
                {
                    _claims.Add(item.Key, item.Value);
                }
            }
            return this;
        }

        public JwtTokenBuilder AddExpiry(int expiryInMinutes)
        {
            _expiryInMinutes = expiryInMinutes;
            return this;
        }

        public JwtToken Build()
        {
            EnsureArguments();

            var claims = new List<Claim>
            {
              new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }
            .Union(_claims.Select(item => new Claim(item.Key, item.Value)));

            var token = new JwtSecurityToken(
                              issuer: _issuer,
                              audience: _audience,
                              claims: claims,
                              expires: DateTime.UtcNow.AddMinutes(_expiryInMinutes),
                              signingCredentials: new SigningCredentials(
                                                        _securityKey,
                                                        SecurityAlgorithms.HmacSha256));

            return new JwtToken(token);
        }

    }
}
