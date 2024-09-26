using Microsoft.EntityFrameworkCore;
using DoctorsNearMe.Application;
using DoctorsNearMe.Data;

namespace DoctorsNearMe.Api;

public static class DI
{
    public static IServiceCollection InjectDeps(
        this IServiceCollection services,
        IConfiguration config)
    {
        services
            .AddControllers()
            .AddJsonOptions(options => {
                options.JsonSerializerOptions.Converters.Add(
                    new NetTopologySuite.IO.Converters.GeoJsonConverterFactory());
            });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddApplication(config);

        return services;
    }

    public static void ApplyMigrations(
        this IApplicationBuilder app,
        bool dev)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();
        using AppDbContext ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        var pending = ctx.Database.GetPendingMigrations();

        ctx.Database.Migrate();

        if (pending.Count() > 0)
        {
            ctx.Seed();

            if (dev)
                ctx.DevSeed();
        }
    }
}
