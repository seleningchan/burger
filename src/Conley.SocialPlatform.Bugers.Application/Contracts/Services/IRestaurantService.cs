using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conley.SocialPlatform.Bugers.Application.Resources;

namespace Conley.SocialPlatform.Bugers.Application.Contracts.Services
{
    public interface IRestaurantService
    {
        public Task<IEnumerable<RestaurantResource>> FindLocalBurgerRestaurantAsync(string city);
        public Task<IEnumerable<RestaurantResource>> FindNearBurgerRestaurantAsync(double longitude, double latitude);
    }
}
