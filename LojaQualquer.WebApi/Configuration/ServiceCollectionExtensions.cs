using LojaQualquer.WebApi.Domain.Interfaces.Repositories;
using LojaQualquer.WebApi.Domain.Interfaces.Services;
using LojaQualquer.WebApi.Domain.Services;
using LojaQualquer.WebApi.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LojaQualquer.WebApi.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureService(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizeService, AuthorizeService>();
            services.AddScoped<ILoginService, LoginService>();
        }

        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}