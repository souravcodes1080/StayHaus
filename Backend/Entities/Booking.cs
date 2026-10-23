using Backend.Enums;

namespace Backend.Entities
{
    public class Booking : Shared
    {
        public Guid RoomId { get; set; }
        public Room Room { get; set; } = null!;
        public required string GuestName { get; set; }
        public required int GuestPhoneNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public BookingStatus BookingStatus { get; set; } = BookingStatus.PendingApproval;
        public decimal PricePerNight { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid? UserId { get; set; }
        public User? User { get; set; }
    }
}