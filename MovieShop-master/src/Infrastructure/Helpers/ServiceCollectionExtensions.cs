using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Helpers;

public static class ServiceCollectionExtensions
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<ICastRepository, CastRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAsyncRepository<Favorite>, EfRepository<Favorite>>();
        services.AddScoped<IAsyncRepository<Purchase>, EfRepository<Purchase>>();
        services.AddScoped<IAsyncRepository<Genre>, EfRepository<Genre>>();
        services.AddScoped<IAsyncRepository<Review>, EfRepository<Review>>();
        services.AddScoped<IPurchaseRepository, PurchaseRepository>();
        services.AddScoped<IReportsRepository, ReportsRepository>();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IMovieService, MovieService>();
        services.AddScoped<IGenreService, GenreService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddScoped<ICastService, CastService>();
        services.AddScoped<IAdminService, AdminService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IFavoriteService, FavoriteService>();
        services.AddScoped<IReviewService, ReviewService>();
        services.AddScoped<IPurchaseService, PurchaseService>();
        services.AddScoped(typeof(ICacheService<>), typeof(RedisCacheService<>));

        //  services.AddScoped<IGenreService, GenreRedisCacheService>();
    }
}