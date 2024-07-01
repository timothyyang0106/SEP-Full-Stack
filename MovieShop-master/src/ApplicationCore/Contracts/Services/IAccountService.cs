using ApplicationCore.Models.RequestModels;
using ApplicationCore.Models.ResponseModels;

namespace ApplicationCore.Contracts.Services;

public interface IAccountService
{
    Task<UserLoginResponseModel> ValidateUser(string email, string password);
    Task<UserRegisterResponseModel> CreateUser(UserRegisterRequestModel requestModel);
}