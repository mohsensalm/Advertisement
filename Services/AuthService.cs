using Advertisement.Entites;
using Advertisement.Interfacecs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Advertisement.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;

        public AuthService(IConfiguration config) => _config = config;

        public string GenerateToken(User user)
        {
            var jwtSettings = _config.GetSection("JwtSettings");
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature),
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        // Temporary user validation method (replace with real data source)
        public User ValidateUser(string username, string password)
        {
            // Hardcoded user (replace with your database logic)
            return username == "testuser" && password == "testpassword" ? new User { UserId = 1, Name = "testuser" } : null;
        }
    }
}
