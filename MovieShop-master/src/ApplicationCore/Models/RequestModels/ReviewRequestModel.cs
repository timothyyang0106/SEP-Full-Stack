using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models.RequestModels
{
    public class ReviewRequestModel
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public string ReviewText { get; set; }
        
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5 stars.")]
        public decimal Rating { get; set; }
    }
}
