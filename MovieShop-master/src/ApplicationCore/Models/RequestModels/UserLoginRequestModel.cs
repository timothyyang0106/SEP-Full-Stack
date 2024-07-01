using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models.RequestModels;

public class UserLoginRequestModel
{
    public UserLoginRequestModel() { }
    public UserLoginRequestModel(string email, string password)
    {
        Email = email;
        Password = password;
    }

    [Required]
    [EmailAddress]
    [StringLength(50)]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}