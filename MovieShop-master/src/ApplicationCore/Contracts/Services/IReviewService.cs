using ApplicationCore.Models.RequestModels;
using ApplicationCore.Models.ResponseModels;

namespace ApplicationCore.Contracts.Services;

public interface IReviewService
{
    Task<ReviewResponseModel> AddMovieReview(ReviewRequestModel reviewRequest);
    Task UpdateMovieReview(ReviewRequestModel reviewRequest);
    Task DeleteMovieReview(ReviewDeleteRequestModel reviewDeleteRequestModel);
    Task<ReviewResponseModel> GetReviewDetails(int movieId, int userId);
}