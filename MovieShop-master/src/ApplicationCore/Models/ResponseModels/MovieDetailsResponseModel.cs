namespace ApplicationCore.Models.ResponseModels;

public class MovieDetailsResponseModel
{
    public MovieDetailsResponseModel()
    {
        Casts = new List<CastResponseModel>();
        Genres = new List<GenreResponseModel>();
        Reviews = new List<UserMovieReviewsResponseModel>();
        Trailers = new List<TrailerResponseModel>();
    }

    public int Id { get; set; }
    public string? Title { get; set; }
    public string? PosterUrl { get; set; }
    public string? BackdropUrl { get; set; }

    public decimal? Rating { get; set; }
    public string? Overview { get; set; }
    public string? Tagline { get; set; }
    public decimal? Budget { get; set; }
    public decimal? Revenue { get; set; }
    public string? ImdbUrl { get; set; }
    public string? TmdbUrl { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public int? RunTime { get; set; }
    public decimal? Price { get; set; }
    public int FavoritesCount { get; set; }
    public List<CastResponseModel> Casts { get; set; }
    public List<GenreResponseModel> Genres { get; set; }
    public List<UserMovieReviewsResponseModel> Reviews { get; set; }
    public List<TrailerResponseModel> Trailers { get; set; }

    public bool IsPurchased { get; set; }  // New property to indicate if the movie is purchased
}