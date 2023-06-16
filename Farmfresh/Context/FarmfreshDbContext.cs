using Farmfresh.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace Farmfresh.Context;

public partial class FarmfreshDbContext : DbContext
{
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();

    public FarmfreshDbContext(DbContextOptions<FarmfreshDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
