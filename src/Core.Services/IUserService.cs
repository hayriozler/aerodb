namespace Core.Services
{
    public interface IUserService
    {
        bool VerifyPassword(string password, string hash, string salt);
    }
}
