using Advertisement.Entites;

namespace Advertisement.Interfacecs
{
    public interface IAuthService
    {
        string GenerateToken(User user);
        User ValidateUser(string username, string password);
    }
}
