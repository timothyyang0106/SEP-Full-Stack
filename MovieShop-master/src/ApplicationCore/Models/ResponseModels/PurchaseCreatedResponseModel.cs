namespace ApplicationCore.Models.ResponseModels;

public class PurchaseCreatedResponseModel
{
    public int UserId { get; set; }
    public int MovieId { get; set; }
    public Guid PurchaseNumber { get; set; }
    public DateTime PurchaseDateTime { get; set; }


}