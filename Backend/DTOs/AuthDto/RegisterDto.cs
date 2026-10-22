using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs.AuthDto
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(50, ErrorMessage = "Name must be less than 50 characters.")]
        public required String Name { get; set; }    

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Must be a valid email address.")]
        [MaxLength(256, ErrorMessage = "Email cannot exceed 256 characters.")]   
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password should be atleast 6 characters long.")]   
        public string Password { get; set; } = ""; 
    }
}