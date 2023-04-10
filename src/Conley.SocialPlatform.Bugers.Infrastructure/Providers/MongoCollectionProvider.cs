using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conley.SocialPlatform.Bugers.Application.Contracts.Infrastructure;
using Conley.SocialPlatform.Bugers.Domain;
using Conley.SocialPlatform.Bugers.Domain.Entities;
using Conley.SocialPlatform.Bugers.Infrastructure.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Conley.SocialPlatform.Bugers.Infrastructure.Providers
{
    public class MongoCollectionProvider : IMongoCollectionProvider
    {
        private readonly IMongoDatabase _mongoDatabase;

        public MongoCollectionProvider(IMongoClientFactory mongoClientFactory, IOptions<MongoSettings> mongoSettings, ILogger<MongoCollectionProvider> logger)
        {
            var client = mongoClientFactory.Build(logger);
            _mongoDatabase = client.GetDatabase(mongoSettings.Value.DatabaseName);
        }

        public IMongoCollection<CategoryEntity> GetCategories() => 
            _mongoDatabase.GetCollection<CategoryEntity>(Constants.MongoCollections.CategoryCollectionName);

        public IMongoCollection<CityEntity> GetCities() =>
            _mongoDatabase.GetCollection<CityEntity>(Constants.MongoCollections.CityCollectionName);

        public IMongoCollection<FoodEntity> GetFoods() =>
            _mongoDatabase.GetCollection<FoodEntity>(Constants.MongoCollections.FoodCollectionName);

        public IMongoCollection<ImageEntity> GetImages() =>
            _mongoDatabase.GetCollection<ImageEntity>(Constants.MongoCollections.ImageCollectionName);

        public IMongoCollection<RatingEntity> GetRatings() =>
            _mongoDatabase.GetCollection<RatingEntity>(Constants.MongoCollections.RatingCollectionName);

        public IMongoCollection<RestaurantEntity> GetRestuarants() =>
            _mongoDatabase.GetCollection<RestaurantEntity>(Constants.MongoCollections.RatingCollectionName);

        public IMongoCollection<UserEntity> GetUsers() =>
            _mongoDatabase.GetCollection<UserEntity>(Constants.MongoCollections.UserCollectionName);
    }
}
