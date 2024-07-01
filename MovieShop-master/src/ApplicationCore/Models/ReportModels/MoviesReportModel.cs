using System.Text.Json.Serialization;

namespace ApplicationCore.Models.ReportModels
{
    public class MoviesReportModel
    {
        public MoviesReportModel(int id, string title, string posterUrl, DateTime releaseDate, int totalPurchases,
            int maxRows)
        {
            Id = id;
            Title = title;
            PosterUrl = posterUrl;
            ReleaseDate = releaseDate;
            TotalPurchases = totalPurchases;
            MaxRows = maxRows;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string PosterUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int TotalPurchases { get; set; }

        [JsonIgnore] public int MaxRows { get; set; }
    }
}