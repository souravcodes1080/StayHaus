using System.ComponentModel.DataAnnotations;

namespace Backend.Enums
{
    public enum HomestayRoomType
    {
        [Display(Name = "Single Room")]
        Single = 1,
        // Tailored and priced for a single solo traveler or remote worker. 
        // Typically contains one single/twin bed and a small workspace.

        [Display(Name = "Double / Couple Room")]
        Double = 2,
        // Designed comfortably for two guests (e.g., a couple or two friends).
        // Typically configured with one double/queen bed or two twin beds.

        [Display(Name = "Family Suite / Room")]
        Family = 3,
        // A larger space or multi-bed room built to accommodate parents and children together.
        // Often includes extra bedding layout options like a king bed plus an adjacent single or bunk bed.

        [Display(Name = "Deluxe / Premium Room")]
        Deluxe = 4,
        // The highest tier room in the homestay. It features superior amenities, 
        // such as an attached private balcony, prime scenic views, or a private en-suite bathroom.

        [Display(Name = "Group / Dormitory Stay")]
        Dormitory = 5
        // Common in budget cultural exchanges or trekking homestays. Multiple single beds or mattresses 
        // are set up in a large hall to accommodate groups or individual backpackers sharing the room space.
    }
}