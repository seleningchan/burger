using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conley.SocialPlatform.Bugers.Application.Contracts.Infrastructure;
using Conley.SocialPlatform.Bugers.Application.Contracts.Services;
using Conley.SocialPlatform.Bugers.Domain.Entities;
using Conley.SocialPlatform.Bugers.Infrastructure.Providers;
using Conley.SocialPlatform.Bugers.Infrastructure.Services;
using Conley.SocialPlatform.Bugers.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Microsoft.Extensions.DependencyInjection;

namespace Conley.SocialPlatform.Bugers.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastrutureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoSettings>(setting=> configuration.GetSection(nameof(MongoSettings)));

            services.AddSingleton<IMongoClientFactory, MongoClientFactory>();
            services.AddSingleton<IMongoCollectionProvider, MongoCollectionProvider>();

            services.AddScoped(servicesProvider => servicesProvider.GetService<IMongoCollectionProvider>().GetCategories());
            services.AddScoped(servicesProvider => servicesProvider.GetService<IMongoCollectionProvider>().GetFoods());
            services.AddScoped(servicesProvider => servicesProvider.GetService<IMongoCollectionProvider>().GetRatings());
            services.AddScoped(servicesProvider => servicesProvider.GetService<IMongoCollectionProvider>().GetRestuarants());
            services.AddScoped(servicesProvider => servicesProvider.GetService<IMongoCollectionProvider>().GetUsers());
            services.AddScoped(servicesProvider => servicesProvider.GetService<IMongoCollectionProvider>().GetImages());
            services.AddScoped(servicesProvider => servicesProvider.GetService<IMongoCollectionProvider>().GetCities());
            services.AddScoped<IStoreProvider, LocalStoreProvider>();
            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IRatingService, RatingService>();
           
            return services;
        }
        
    }
}
