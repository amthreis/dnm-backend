using NTier.Data.Entities;
using System.Diagnostics;
using System.Numerics;

namespace NTier.Data;

public static class Seeders
{
    public static void Seed(this AppDbContext ctx)
    {
        Debug.WriteLine("Seeding...");

        ctx.SaveChanges();
    }

    public static void DevSeed(this AppDbContext ctx)
    {
        Debug.WriteLine("Seeding (dev)...");

        var gf = NetTopologySuite.NtsGeometryServices.Instance.CreateGeometryFactory(4326);

        ctx.Users.Add(new User
        {
            Name = "Leila",
            Email = "leila@m.com",
            PublicId = Guid.NewGuid(),
        });

        var a = new Patient
        {
            User = new User
            {
                Name = "Andreia",
                Email = "andreia@m.com",
                PublicId = Guid.NewGuid(),
            }
        };

        ctx.Patients.Add(a);

        var ms = new Patient
        {
            User = new User
            {
                Name = "Marcos",
                Email = "marcos@m.com",
                PublicId = Guid.NewGuid(),
            }
        };

        ctx.Patients.Add(ms);

        ctx.SaveChanges();
    }
}
