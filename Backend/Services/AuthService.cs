using Backend.Data;
using Backend.DTOs.AuthDto;
using Backend.Entities;
using Backend.Exceptions;
using Backend.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class AuthService(AppDbContext context, ITokenService tokenService, IPasswordHasher<User> passwordHasher) : IAuthService
    {
        private readonly AppDbContext context = context;
        private readonly ITokenService tokenService = tokenService;
        private readonly IPasswordHasher<User> passwordHasher = passwordHasher;

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
            var email = user.Email.Trim().ToLower();

            var existingUser = await context.User.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email) ?? throw new BadRequestException("Invalid email or password.");

            var result = passwordHasher.VerifyHashedPassword(existingUser, existingUser.HashedPassword, user.Password);

            if(result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid email or password.");
            }

            return new AuthResponseDto
            {
                Id = existingUser.Id,
                Name = existingUser.Name,
                Email = existingUser.Email,
                Role = existingUser.Role,
                Token = tokenService.CreateToken(existingUser)
            }; 
        }
    }
}