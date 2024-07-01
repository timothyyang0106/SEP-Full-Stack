using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models.RequestModels;
using ApplicationCore.Models.ResponseModels;

namespace Infrastructure.Services;

public class PurchaseService : IPurchaseService
{
    private readonly IMovieRepository _movieRepository;
    private readonly IAsyncRepository<Purchase> _purchaseRepository;

    public PurchaseService(IAsyncRepository<Purchase> purchaseRepository, IMovieRepository movieRepository)
    {
        _purchaseRepository = purchaseRepository;
        _movieRepository = movieRepository;
    }

    public async Task<PurchaseCreatedResponseModel> PurchaseMovie(PurchaseRequestModel purchaseRequestModel)
    {
        var moviePrice = await _movieRepository.GetMoviePrice(purchaseRequestModel.MovieId);
        if (moviePrice == null)
            throw new NotFoundException($"Movie Price not found for movie {purchaseRequestModel.MovieId}");

        var purchase = new Purchase
        {
            UserId = purchaseRequestModel.UserId,
            MovieId = purchaseRequestModel.MovieId,
            PurchaseNumber = purchaseRequestModel.PurchaseNumber,
            PurchaseDateTime = purchaseRequestModel.PurchaseDateTime,
            TotalPrice = moviePrice.Value
        };

        var createdPurchase = await _purchaseRepository.AddAsync(purchase);
        return new PurchaseCreatedResponseModel
        {
            MovieId = createdPurchase.MovieId,
            PurchaseNumber = createdPurchase.PurchaseNumber,
            UserId = createdPurchase.UserId,
            PurchaseDateTime = createdPurchase.PurchaseDateTime
        };
    }

    public async Task<bool> IsMoviePurchased(int userId, int movieId)
    {
        var moviePurchased = await _purchaseRepository.GetExistsAsync(p =>
            p.UserId == userId && p.MovieId == movieId);
        return moviePurchased;
    }

    public async Task<PurchaseDetailsResponseModel> GetPurchasesDetails(int userId, int movieId)
    {
        throw new NotImplementedException();
    }
}