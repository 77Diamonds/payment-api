using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Seventy7Diamonds.Payment.Infrastructure.Database;
using Seventy7Diamonds.Payment.Infrastructure.Options;
using Seventy7Diamonds.Payment.Infrastructure.Services.CheckoutDotCom;
using SeventySevenDiamonds.Payments.Domain.Interfaces;

namespace Seventy7Diamonds.Payment.Infrastructure;

/// <summary>
/// Static class containing dependencies for the infra layer
/// </summary>
public static class ConfigureServices
{
    /// <summary>
    /// Configure all infra services
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddTransient<IPaymentService, PaymentService>();
        
        services.AddDbContext<PaymentDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("Postgres"));
        });
        
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(configuration["RabbitMq:Host"], "/", h =>
                {
                    h.Password(configuration["RabbitMq:Username"]!);
                    h.Password(configuration["RabbitMq:Password"]!);
                });
            });
        });
        

        return services;
    }
}