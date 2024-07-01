using ApplicationCore.Models.RequestModels;
using ApplicationCore.Models.ResponseModels;

namespace ApplicationCore.Contracts.Services;

public interface IPurchaseService
{
    Task<PurchaseCreatedResponseModel> PurchaseMovie(PurchaseRequestModel purchase);
    Task<bool> IsMoviePurchased(int userId, int movieId);
    Task<PurchaseDetailsResponseModel> GetPurchasesDetails(int userId, int movieId);
}