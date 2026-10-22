using Backend.DTOs.AuthDto;

namespace Backend.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterDto user);
        Task<AuthResponseDto> LoginAsync(LoginDto user);
    }
}