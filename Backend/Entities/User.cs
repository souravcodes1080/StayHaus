using System.ComponentModel.DataAnnotations;
using Backend.Enums;

namespace Backend.Entities
{
    public class User : Shared
    {
        [MaxLength(50)]
        public required String Name { get; set; }

        [MaxLength(256)]
        public required string Email { get; set; }

        [MaxLength(256)]
        public string HashedPassword { get; set; } = "";

        [MaxLength(10)]
        public string? PhoneNumber { get; set; }
        
        public Role Role { get; set; } = Role.User;

        public List<Booking> Bookings { get; set; } = [];
    }
}