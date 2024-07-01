namespace ApplicationCore.Models.ResponseModels;

public class MovieCardResponseModel
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? PosterUrl { get; set; }
    public DateTime ReleaseDate { get; set; }
}