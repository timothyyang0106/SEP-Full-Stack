using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models.ResponseModels;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Services
{
    public class GenreService : IGenreService
    {
        private readonly IAsyncRepository<Genre> _genreRepository;
        private static readonly TimeSpan DefaultCacheDuration = TimeSpan.FromDays(30);
        private static readonly string _genresKey = "genres";
        private readonly IMemoryCache _cache;

        public GenreService(IAsyncRepository<Genre> genreRepository, IMemoryCache cache)
        {
            _genreRepository = genreRepository;
            _cache = cache;
        }

        public async Task<IEnumerable<GenreResponseModel>> GetAllGenres()
        {
            var genres = await _cache.GetOrCreateAsync(_genresKey, Factory);
            return genres.OrderBy(g => g.Name);
        }

        private async Task<IEnumerable<GenreResponseModel>> Factory(ICacheEntry entry)
        {
            entry.SlidingExpiration = DefaultCacheDuration;
            var dbGenres = await _genreRepository.ListAllAsync();
            var genres = dbGenres.Select(g => new GenreResponseModel
            {
                Id = g.Id, Name = g.Name
            });
            return genres;
        }
    }
}