using Microsoft.EntityFrameworkCore;

namespace KolokwiumCF.Models;

public class KoloContext : DbContext
{
    public KoloContext()
    {
    }

    public KoloContext(DbContextOptions<KoloContext> options) : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<Discount> Discounts { get; set; }
    public virtual DbSet<Payment> Payments { get; set; }
    public virtual DbSet<Sale> Sales { get; set; }
    public virtual DbSet<Subscription> Subscriptions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(KoloContext).Assembly);
    }
}