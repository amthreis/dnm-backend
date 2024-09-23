using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NTier.Data.Entities;
using NTier.Data.Repositories;
using System.Diagnostics;
using System.Numerics;

namespace NTier.Data;

public static class DI
{
    public static IServiceCollection AddData(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }

    public static void DevSeed(this AppDbContext ctx)
    {
        Debug.WriteLine("Seeding...");

        var gf = NetTopologySuite.NtsGeometryServices.Instance.CreateGeometryFactory(4326);

        ctx.Users.Add(new User
        {
            Name = "Leila",
            Email = "leila@m.com",
        });

        ctx.SaveChanges();
    }
}
