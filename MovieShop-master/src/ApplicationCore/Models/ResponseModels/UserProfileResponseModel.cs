namespace ApplicationCore.Models.ResponseModels;

public class UserProfileResponseModel
{
    public UserProfileResponseModel(int id, string email, string firstName, string lastName, DateTime? dateOfBirth,
        string? phoneNumber, string? profilePictureUrl, List<RoleResponseModel>? roles = null)
    {
        Id = id;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        ProfilePictureUrl = profilePictureUrl;
        Roles = roles;
    }

    public int Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? PhoneNumber { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public List<RoleResponseModel>? Roles { get; }
}