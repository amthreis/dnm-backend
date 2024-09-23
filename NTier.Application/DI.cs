using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NTier.Data;

namespace NTier.Application;

public static class DI
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddScoped<IUserService, UserService>();

        services.AddData(config);

        return services;
    }
}
