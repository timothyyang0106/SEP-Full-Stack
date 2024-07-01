namespace ApplicationCore.Models.ResponseModels;

public class UserLoginResponseModel
{
    public UserLoginResponseModel(int id, string email, string firstName, string lastName, DateTime? dateOfBirth, List<RoleResponseModel>? roles)
    {
        Id = id;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Roles = roles;
    }

    public int Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public List<RoleResponseModel>? Roles { get; set; }
}