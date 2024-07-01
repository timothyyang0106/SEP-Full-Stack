using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models.RequestModels;
using ApplicationCore.Models.ResponseModels;

namespace Infrastructure.Services;

public class AccountService : IAccountService
{
    private readonly IUserRepository _userRepository;

    public AccountService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserLoginResponseModel> ValidateUser(string email, string password)
    {
        var user = await _userRepository.GetUserByEmail(email);
        if (user == null) throw new UnauthorizedAccessException("Email does not exists");
        var hashedPassword = GetHashPassword(password, user.Salt);
        var isSuccess = user.HashedPassword == hashedPassword;
        var response = new UserLoginResponseModel(user.Id, user.Email, user.FirstName, user.LastName, user.DateOfBirth,
            user.RolesOfUser.Select(r => new RoleResponseModel { Id = r.RoleId, Name = r.Role.Name }).ToList());

        return isSuccess ? response : throw new UnauthorizedAccessException("check email/password");
        ;
    }

    public async Task<UserRegisterResponseModel> CreateUser(UserRegisterRequestModel requestModel)
    {
        var dbUser = await _userRepository.GetUserByEmail(requestModel.Email);
        if (dbUser != null &&
            string.Equals(dbUser.Email, requestModel.Email, StringComparison.CurrentCultureIgnoreCase))
            throw new ConflictException("Email Already Exits");
        var salt = GetRandomSalt();
        var hashedPassword = GetHashPassword(requestModel.Password, salt);
        var user = new User
        {
            Email = requestModel.Email,
            Salt = salt,
            HashedPassword = hashedPassword,
            FirstName = requestModel.FirstName,
            LastName = requestModel.LastName
        };
        var createdUser = await _userRepository.AddAsync(user);

        var response = new UserRegisterResponseModel(
            createdUser.Id,
            createdUser.Email,
            createdUser.FirstName,
            createdUser.LastName
        );

        return response;
    }

    private string GetRandomSalt()
    {
        var randomBytes = new byte[128 / 8];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomBytes);
        }

        return Convert.ToBase64String(randomBytes);
    }

    private string GetHashPassword(string password, string salt)
    {
        var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password,
            Convert.FromBase64String(salt),
            KeyDerivationPrf.HMACSHA512,
            10000,
            256 / 8));
        return hashed;
    }
}