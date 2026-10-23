using Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users {get; set;}
        public DbSet<Homestay> Homestays {get; set;}
        public DbSet<Room> Rooms {get; set;}
        public DbSet<Booking> Bookings {get; set;}
    }
}