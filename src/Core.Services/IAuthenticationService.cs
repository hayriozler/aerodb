using System.Threading.Tasks;
using Core.Domain;
using Core.Domain.Users;

namespace Core.Services
{
    public interface IAuthenticationService
    {
        Task<UserToken> CreateTokenAsync(User user, string password);
    }
}
