namespace ApplicationCore.Models.ResponseModels;

public class MovieReviewResponseModel
{
    public int UserId { get; set; }
    public int MovieId { get; set; }
    public string ReviewText { get; set; }
    public decimal Rating { get; set; }
    public string Title { get; set; }
}