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
                message: "User registration sucessfull!",
                data: result
            ));
        }
    }
}