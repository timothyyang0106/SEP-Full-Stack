using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models.ResponseModels;

namespace Infrastructure.Services;

public class GenreRedisCacheService : IGenreService
{
    private readonly ICacheService<GenreResponseModel> _cacheService;
    private readonly IAsyncRepository<Genre> _genreRepository;

    public GenreRedisCacheService(ICacheService<GenreResponseModel> cacheService, IAsyncRepository<Genre> genreRepository)
    {
        _cacheService = cacheService;
        _genreRepository = genreRepository;
    }

    public async Task<IEnumerable<GenreResponseModel>> GetAllGenres()
    {
        var data = await _cacheService.GetListCacheValueAsync("genres");
        if (data != null) return data ;
        var dbGenres = await _genreRepository.ListAllAsync();
        var genres = dbGenres.Select(g => new GenreResponseModel
        {
            Id = g.Id, Name = g.Name
        });

        var genreModels = genres.ToList();
        await _cacheService.SetListCacheValueAsync("genres", genreModels.ToList());
        return genreModels;

    }
}