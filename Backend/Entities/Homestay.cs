using System.ComponentModel.DataAnnotations;

namespace Backend.Entities
{
    public class Homestay : Shared
    {
        [MaxLength(256)]
        public required string Name { get; set; }

        [MaxLength(256)]
        public required string Location { get; set; }

        [MaxLength(500)]
        public string Description { get; set; } = String.Empty;

        [MaxLength(500)]
        public string Address { get; set; } = String.Empty;
        public double Rating { get; set; }
        public List<string> Images { get; set; } = [];
        public List<string> Amenities { get; set; } = [];
        public List<Room> Rooms { get; set; } = [];
    }
}