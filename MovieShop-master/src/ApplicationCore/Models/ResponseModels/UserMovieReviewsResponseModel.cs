namespace ApplicationCore.Models.ResponseModels;

public class UserMovieReviewsResponseModel
{
    public UserMovieReviewsResponseModel()
    {
        MovieReviews = new List<MovieReviewResponseModel>();
    }

    public int UserId { get; set; }
    public List<MovieReviewResponseModel> MovieReviews { get; set; }
}