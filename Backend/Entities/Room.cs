using System.ComponentModel.DataAnnotations;
using Backend.Enums;

namespace Backend.Entities
{
    public class Room : Shared
    {
        public required int RoomNumber { get; set; }

        [MaxLength(500)]
        public string Description { get; set; } = String.Empty;
        public int Capacity { get; set; }
        public int NumberOfBeds { get; set; }
        public string BedType { get; set; } = string.Empty;
        public bool HasBalcony { get; set; }
        public string ViewType { get; set; } = string.Empty;
        public double RoomSize { get; set; }
        public List<string> Images { get; set; } = [];
        public List<string> Amenities { get; set; } = [];
        public decimal Price { get; set; }
        public HomestayRoomType Type { get; set; }

        public Guid HomestayId { get; set; }
        public Homestay Homestay { get; set; } = null!;
        public List<Booking> Bookings { get; set; } = [];
    }
}