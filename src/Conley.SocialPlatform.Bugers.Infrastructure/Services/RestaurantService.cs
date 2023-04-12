using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Conley.SocialPlatform.Bugers.Application.Contracts.Persistence;
using Conley.SocialPlatform.Bugers.Application.Resources;
using Conley.SocialPlatform.Bugers.Application.Contracts.Services;
using Conley.SocialPlatform.Bugers.Domain.Entities;

namespace Conley.SocialPlatform.Bugers.Infrastructure.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;
        public RestaurantService(IRestaurantRepository restaurantRepository, ICityRepository cityRepository, 
            IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RestaurantResource>> FindLocalBurgerRestaurantAsync(string cityName)
        {
            var city = await _cityRepository.GetCityByNameAsync(cityName);
            var restaurants = (await _restaurantRepository.FindRestaurantByCity(city.CityId))
                                .Where(n => n.ContainBurger)
                                .ToList();
            var restaurantResources=_mapper.Map<IEnumerable<RestaurantEntity>, IEnumerable<RestaurantResource>>(restaurants);
            return restaurantResources;
        }

        public async Task<IEnumerable<RestaurantResource>> FindNearBurgerRestaurantAsync(double longitude, double latitude)
        {
            var restaurants = (await _restaurantRepository.FindNearRestaurant(longitude, latitude))
                                .Where(n => n.ContainBurger)
                                .ToList();
            var restaurantResources = _mapper.Map<IEnumerable<RestaurantEntity>, IEnumerable<RestaurantResource>>(restaurants);
            return restaurantResources;
        }
    }
}
