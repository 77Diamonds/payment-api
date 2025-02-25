using Microsoft.AspNetCore.Mvc;

namespace Seventy7Diamonds.Payments.Api.Models;

/// <summary>
/// ApiVersion class holds a list of all supported API versions.
/// </summary>
public static class ApiVersions
{
    /// <summary>
    /// Version 1 of the API.
    /// </summary>
    public const string V1 = "1";
}


public static class ConfigureApiVersions
{
    /// <summary>
    /// Configures api versioning on the pipeline
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddVersioning(
        this IServiceCollection services)
    {
        services.AddApiVersioning(setup =>
        {
            setup.DefaultApiVersion = new ApiVersion(1, 0);
            setup.AssumeDefaultVersionWhenUnspecified = true;
            setup.ReportApiVersions = true;
        });
        return services;
    }
}

