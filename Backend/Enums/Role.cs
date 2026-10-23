using System.ComponentModel.DataAnnotations;

namespace Backend.Enums
{
    public enum Role
    {
        [Display(Name = "Admin")]
        Admin = 1,
        // Internal system administrator

        [Display(Name = "Guest")]
        User = 2
        // Travelers looking for and booking homestays
    }
}