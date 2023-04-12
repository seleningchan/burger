using Conley.SocialPlatform.Bugers.Application.Contracts.Persistence;
using Conley.SocialPlatform.Bugers.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Conley.SocialPlatform.Bugers.Persistence
{
    public static class PersistenceServicesRegisstration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services)
        {
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IFoodRepository, FoodRepository>();
            services.AddScoped<IRatingRepositry, RatingRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IImageRepository,ImageRepository>();
            return services;
        }
    }
}
