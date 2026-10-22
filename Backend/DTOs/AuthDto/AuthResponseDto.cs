using Backend.Enums;

namespace Backend.DTOs.AuthDto
{
    public class AuthResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public Role Role { get; set; }
        public string Token { get; set; } = String.Empty;
    }
}