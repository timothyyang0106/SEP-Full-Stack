using System.ComponentModel.DataAnnotations;
using ApplicationCore.Validations;

namespace ApplicationCore.Models.RequestModels
{
    public class UserRegisterRequestModel
    {
        public UserRegisterRequestModel() { }
        public UserRegisterRequestModel(string email, string password, string firstName, string lastName,
            DateTime dateOfBirth)
        {
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$", ErrorMessage =
            "Password Should have minimum 8 with at least one upper, lower, number and special character")]
        public string Password { get; set; }

        [StringLength(50)] public string FirstName { get; set; }

        [StringLength(50)] public string LastName { get; set; }

        [DataType(DataType.Date)]
        [MaximumYear(1910)]
        [MinimumAge(18)]
        public DateTime DateOfBirth { get; set; }
    }
}