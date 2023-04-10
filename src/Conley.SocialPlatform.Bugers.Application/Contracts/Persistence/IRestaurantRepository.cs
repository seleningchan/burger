using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conley.SocialPlatform.Bugers.Domain.Entities;

namespace Conley.SocialPlatform.Bugers.Application.Contracts.Persistence
{
    public interface IRestaurantRepository : IGenericRepository<RestaurantEntity>
    {
        public Task<IList<RestaurantEntity>> FindRestaurantByCity(int cityId);
        public Task<IList<RestaurantEntity>> FindNearRestaurant(double longitude, double latitude);
    }
}
