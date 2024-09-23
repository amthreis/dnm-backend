using Microsoft.EntityFrameworkCore;
using NTier.Data.Entities;

namespace NTier.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        
    }

    public DbSet<User> Users {  get; set; }
}
