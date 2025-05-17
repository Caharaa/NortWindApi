using NorthwindAPI.Data;
using NorthwindAPI.Models;
using NorthwindAPI.Dto;

namespace NorthwindAPI.Services
{
    public interface IAuthService
    {
        Task<User?> Register(UserDto request);
        Task<TokenDto?> Login(UserDto request);
    }
}