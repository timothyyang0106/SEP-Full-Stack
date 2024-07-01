namespace ApplicationCore.Models.ResponseModels;

public class PurchaseResponseModel
{
    public int UserId { get; set; }
    public int TotalMoviesPurchased { get; set; }
    public List<MovieCardResponseModel> PurchasedMovies { get; set; } = new List<MovieCardResponseModel>();
}