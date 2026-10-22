using Backend.Data;
using Backend.DTOs.AuthDto;
using Backend.Entities;
using Backend.Exceptions;
using Backend.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class AuthService (AppDbContext context, ITokenService tokenService) : IAuthService
    {
        public async Task<AuthResponseDto> RegisterAsync(RegisterDto user)
        {
            var email = user.Email.Trim().ToLower();

            var existingUser = await context.User.AnyAsync(u=>u.Email == email);

            if (existingUser)
            {
                throw new BadRequestException("Email already registered.");
            }

            var newUser = new User
            {
                Name = user.Name,
                Email = email,
            };

            var passwordHasher = new PasswordHasher<User>();

            newUser.HashedPassword = passwordHasher.HashPassword(newUser, user.Password);

            await context.User.AddAsync(newUser);
            await context.SaveChangesAsync();

            return new AuthResponseDto
            {
                Id = newUser.Id,
                Name = newUser.Name,
                Email = newUser.Email,
                Role = newUser.Role,
                Token = tokenService.CreateToken(newUser)
            };
        }
        public async Task<AuthResponseDto> LoginAsync(LoginDto user)
        {
            throw new NotImplementedException();
        }
    }
}