using ApplicationCore.Models.RequestModels;
using ApplicationCore.Models.ResponseModels;

namespace Infrastructure.Helpers;

public static class ModelMapper
{
    // Entities to Models
    public static MovieCardResponseModel ToMovieCardResponseModel(this Movie movie)
    {
        return new MovieCardResponseModel
        {
            Id = movie.Id, Title = movie.Title, PosterUrl = movie.PosterUrl,
            ReleaseDate = movie.ReleaseDate.GetValueOrDefault()
        };
    }

    public static UserProfileResponseModel ToUserProfileResponseModel(this User user)
    {
        return new UserProfileResponseModel
        (
            user.Id,
            user.Email,
            user.FirstName,
            user.LastName,
            user.DateOfBirth,
            user.PhoneNumber,
            user.ProfilePictureUrl
        );
    }

    public static MovieCardResponseModel ToMovieCardResponseModel(this Favorite favorite)
    {
        return new MovieCardResponseModel
        {
            Id = favorite.MovieId, Title = favorite.Movie.Title, PosterUrl = favorite.Movie.PosterUrl,
            ReleaseDate = favorite.Movie.ReleaseDate.GetValueOrDefault()
        };
    }

    // Models to Entities

    public static Favorite ToFavoriteEntity(this FavoriteRequestModel favoriteRequestModel)
    {
        return new Favorite
        {
            MovieId = favoriteRequestModel.MovieId, UserId = favoriteRequestModel.UserId
        };
    }

    public static Review ToReviewEntity(this ReviewRequestModel reviewRequestModel)
    {
        return new Review
        {
            UserId = reviewRequestModel.UserId, Rating = reviewRequestModel.Rating,
            ReviewText = reviewRequestModel.ReviewText, MovieId = reviewRequestModel.MovieId
        };
    }
}