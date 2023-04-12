using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conley.SocialPlatform.Bugers.Application.Contracts.Persistence;
using Conley.SocialPlatform.Bugers.Application.Exceptions;
using Conley.SocialPlatform.Bugers.Application.Extensions;
using Conley.SocialPlatform.Bugers.Domain.Entities;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Conley.SocialPlatform.Bugers.Persistence.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly IMongoCollection<RestaurantEntity> _restuarantMongoCollection;
        private readonly IMongoCollection<FoodEntity> _foodCollection;
        private readonly ILogger<RestaurantRepository> _logger;

        public RestaurantRepository(IMongoCollection<RestaurantEntity> restuarantMongoCollection,
            ILogger<RestaurantRepository> logger, IMongoCollection<FoodEntity> foodCollection)
        {
            _restuarantMongoCollection = restuarantMongoCollection;
            _foodCollection = foodCollection;
            _logger = logger;
        }

        public async Task AddEntityAsync(RestaurantEntity restaurant)
        {
            try
            {
                await _restuarantMongoCollection.InsertOneAsync(restaurant);
            }
            catch (MongoWriteException ex) when (ex.WriteError.Category == ServerErrorCategory.DuplicateKey)
            {
                throw new RestaurantExistsException(restaurant, ex);
            }
        }

        public async Task<IList<RestaurantEntity>> FindNearRestaurant(double longitude, double latitude)
        {
            var burgerRestaurants = _foodCollection.Find(n => n.CategoryId == 1).ToList();
            var gp = new GeoJsonPoint<GeoJson2DGeographicCoordinates>(new GeoJson2DGeographicCoordinates(longitude, latitude));
            var query = Builders<RestaurantEntity>.Filter.Near("Location", gp, 2000);
            //var result = await _restuarantMongoCollection
            //    .Find(query)
            //    .LogCommand(_logger)
            //    .ToListAsync();
            var result = await _restuarantMongoCollection.AsQueryable().ToListAsync();
            result = result.Where(n => burgerRestaurants.Select(x => x.RestaurantId).Contains(n.RestaurantId)).ToList();
            return result;
        }

        public async Task<IList<RestaurantEntity>> FindRestaurantByCity(int cityId)
        {
            using (var cursor = await _restuarantMongoCollection
                .Find(n => n.CityId == cityId)
                .LogCommand(_logger)
                .ToCursorAsync())
            {
                return await cursor.ToListAsync();
            }
        }
    }
}
