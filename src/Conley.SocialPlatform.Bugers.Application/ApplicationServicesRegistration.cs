using Conley.SocialPlatform.Bugers.Application.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace Conley.SocialPlatform.Bugers.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }
    }
}
