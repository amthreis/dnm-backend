using NTier.Application;

namespace NTier.Api;

public static class DI
{
    public static IServiceCollection InjectDeps(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddApplication(config);

        return services;
    }
}
