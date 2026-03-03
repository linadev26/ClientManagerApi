using Microsoft.AspNetCore.Mvc;
using ClientManagerApi.Data;
using ClientManagerApi.Dtos.Auth;
using ClientManagerApi.Services;

namespace ClientManagerApi.Controllers
{    

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterRequest request)
        {
            var result = await _authService.RegisterAsync(request);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginRequest request)
        {
            var token = await _authService.LoginAsync(request);

            if (token == null)
                return Unauthorized("Invalid email or password");

            return Ok(new { token });
        }
    }
}
