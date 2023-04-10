using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conley.SocialPlatform.Bugers.Domain.Entities;
using MongoDB.Driver;

namespace Conley.SocialPlatform.Bugers.Application.Contracts.Infrastructure
{
    public interface IMongoCollectionProvider
    {
        IMongoCollection<CategoryEntity> GetCategories();
        IMongoCollection<FoodEntity> GetFoods();
        IMongoCollection<RatingEntity> GetRatings();
        IMongoCollection<RestaurantEntity> GetRestuarants();
        IMongoCollection<UserEntity> GetUsers();
        IMongoCollection<ImageEntity> GetImages();
        IMongoCollection<CityEntity> GetCities();
    }
}
