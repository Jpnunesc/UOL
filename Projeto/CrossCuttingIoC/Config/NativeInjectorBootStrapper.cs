
using Business.Interfaces.Repositories;
using Business.Interfaces.Services;
using Business.Services;
using Infra.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.IoC.Config
{
    public class NativeInjectorBootStrapper
    {
        public static IServiceCollection Registered { get; private set; }
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<INotificationRepository, NotificationRepository>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<ITokenService, TokenService>();


        }
    }
}


