namespace ApplicationCore.Models.ResponseModels;

public class PurchaseDetailsResponseModel 
{
    public int UserId { get; set; }
    public Guid PurchaseNumber { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime PurchaseDateTime { get; set; }
    public int MovieId { get; set; }
    public string? Title { get; set; }
    public string? PosterUrl { get; set; }
    public DateTime ReleaseDate { get; set; }
}