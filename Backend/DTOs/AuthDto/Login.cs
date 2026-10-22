using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs.AuthDto
{
    public class Login
    {
        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Must be a valid email address.")]
        [MaxLength(256, ErrorMessage = "Email cannot exceed 256 characters.")]   
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MaxLength(100, ErrorMessage = "Password is too long.")] 
        public string Password { get; set; } = ""; 
    }
}