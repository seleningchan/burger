using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conley.SocialPlatform.Bugers.Application.Contracts.Persistence;
using Conley.SocialPlatform.Bugers.Domain.Entities;
using MongoDB.Driver;

namespace Conley.SocialPlatform.Bugers.Persistence.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly IMongoCollection<ImageEntity> _imageCollection;

        public async Task AddEntityAsync(ImageEntity entity)
        {
            await _imageCollection.InsertOneAsync(entity);
        }
    }
}
