using System.Security.Claims;
using System.Threading.Tasks;
using AeroDb.Core.Jwt;
using Core.Domain;
using Core.Domain.Users;
using MediatR;

namespace Core.Services
{
    public class AuthenticationService
    : IAuthenticationService
    {
        private readonly IMediator _mediator;
        public AuthenticationService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<UserToken> CreateTokenAsync(User user, string password)
        {
            var jwtTokenBuilder = new JwtTokenBuilder();
            jwtTokenBuilder.AddClaim(ClaimTypes.Email, user.Email);
            jwtTokenBuilder.AddClaim(ClaimTypes.Name, user.Name);
            jwtTokenBuilder.AddClaim(ClaimTypes.GivenName, user.Surname);
            var jwtToken = jwtTokenBuilder.Build();
            await _mediator.Publish(new UserLoggedInEvent(user));
            return new UserToken
            {
                ExpiryDateTime = jwtToken.ValidTo,
                Token = jwtToken.Value
            };
        }
    }
}
