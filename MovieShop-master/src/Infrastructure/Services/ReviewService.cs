using ApplicationCore.Contracts.Services;
using ApplicationCore.Models.RequestModels;
using ApplicationCore.Models.ResponseModels;

namespace Infrastructure.Services;

public class ReviewService : IReviewService
{
    public async Task<ReviewResponseModel> AddMovieReview(ReviewRequestModel reviewRequest)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateMovieReview(ReviewRequestModel reviewRequest)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteMovieReview(ReviewDeleteRequestModel reviewDeleteRequestModel)
    {
        throw new NotImplementedException();
    }

    public async Task<ReviewResponseModel> GetReviewDetails(int movieId, int userId)
    {
        throw new NotImplementedException();
    }
}