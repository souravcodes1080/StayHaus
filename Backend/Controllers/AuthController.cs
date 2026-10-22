using Backend.DTOs.AuthDto;
using Backend.Interfaces;
using Backend.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IAuthService service) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse<AuthResponseDto>>> Register([FromBody] RegisterDto user)
        {
            var result = await service.RegisterAsync(user);
            return Ok(new ApiResponse<AuthResponseDto>
            (
                success: true,
                message: "User registration successful.",
                data: result
            ));
        }
        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse<AuthResponseDto>>> Login([FromBody] LoginDto user)
        {
            var result = await service.LoginAsync(user);
            return Ok(new ApiResponse<AuthResponseDto>
            (
                success: true,
                message: "User login successful.",
                data: result
            ));
        }
    }
}