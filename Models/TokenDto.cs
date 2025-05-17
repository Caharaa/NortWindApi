using Microsoft.EntityFrameworkCore;
namespace NorthwindAPI.Models
{
    [Keyless]
    public class TokenDto
    {
        public required string? AccessToken { get; set; }
        public required string? RefreshToken { get; set; }
    }
}