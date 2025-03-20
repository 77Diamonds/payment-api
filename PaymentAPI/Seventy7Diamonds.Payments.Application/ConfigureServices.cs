using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Seventy7Diamonds.Payment.Infrastructure.Options;

namespace Seventy7Diamonds.Payments.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMediatR(delegate(MediatRServiceConfiguration config)
        {
            config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());            
        }); 
        
        //services.AddSingleton<>()
        
        return services;
    }
}