using Microsoft.AspNetCore.Http;

namespace ApplicationCore.Models.RequestModels;

public class UserProfileRequestModel
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public IFormFile File { get; set; } = null!;
}