using System.Threading.Tasks;
using Conley.SocialPlatform.Bugers.Application.Contracts.Persistence;
using Conley.SocialPlatform.Bugers.Application.Extensions;
using Conley.SocialPlatform.Bugers.Domain.Entities;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace Conley.SocialPlatform.Bugers.Persistence.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly IMongoCollection<CityEntity> _cityCollection;
        private readonly ILogger<CityRepository> _logger;

        public CityRepository(IMongoCollection<CityEntity> ratingCollection, ILogger<CityRepository> logger)
        {
            _cityCollection = ratingCollection;
            _logger = logger;
        }
        public async Task AddEntityAsync(CityEntity entity)
        {
            await _cityCollection.InsertOneAsync(entity);
        }

        public async Task<CityEntity> GetCityByNameAsync(string cityName)
        {
            using (var cursor = await _cityCollection
                .Find(n => n.CityName == cityName)
                .LogCommand(_logger)
                .ToCursorAsync())
            {
                return await cursor.FirstOrDefaultAsync();
            }
        }
    }
}
