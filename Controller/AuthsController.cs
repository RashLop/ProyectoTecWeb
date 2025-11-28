using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ProyectoTecWeb.Models.DTO;
using ProyectoTecWeb.Services;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace ProyectoTecWeb.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service)
        {
            _service = service;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
        {
            var id = await _service.RegisterAsync(dto);
            return CreatedAtAction(nameof(Register), new { id = id , message = "Usuario creado"} );
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto dto)
        {
            
            try
            {
                var (ok, response) = await _service.LoginAsync(dto);
                if (!ok || response is null) return Unauthorized(new { message = "Invalid credentials", code = 401 });
                return Ok(response); 
            }
            catch (ArgumentException ex)
            {
                if (ex.Message.Contains("Email"))
                return NotFound(new { message = ex.Message, code = 404 });

                if (ex.Message.Contains("Password"))
                return Unauthorized(new { message = ex.Message, code = 401 });

                return BadRequest(new { message = ex.Message, code = 400 });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Internal server error", code = 500 });
            }
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshRequestDto dto)
        {
            var (ok, response) = await _service.RefreshAsync(dto);
            if (!ok || response is null) return Unauthorized();
            return Ok(response);
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;

            if (userEmail is null)
                return Unauthorized();

            await _service.LogoutAsync(userEmail);
            return Ok(new { message = "Logged out successfully" });
        }

    }
}
