using Advertisement.Entites;
using Advertisement.Interfacecs;
using Microsoft.AspNetCore.Mvc;

namespace Advertisement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) => _authService = authService;

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            var user = _authService.ValidateUser(loginRequest.Username, loginRequest.Password);
            if (user == null) return Unauthorized();

            var token = _authService.GenerateToken(user);
            return Ok(new { Token = token });
        }
    }
}
