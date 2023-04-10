using System.Threading.Tasks;
using Conley.SocialPlatform.Bugers.Domain.Entities;
using MongoDB.Driver;

namespace Conley.SocialPlatform.Bugers.Application.Contracts.Persistence
{
    public class ImageRepository : IGenericRepository<ImageEntity>
    {
        private readonly IMongoCollection<ImageEntity> _imageCollection;

        public async Task AddEntityAsync(ImageEntity entity)
        {
            await _imageCollection.InsertOneAsync(entity);
        }
    }
}
