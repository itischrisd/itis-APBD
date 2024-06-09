using KolokwiumCF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KolokwiumCF.Configurations;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.HasKey(e => e.IdSale)
            .HasName("IdSale_PK");

        builder.Property(e => e.IdSale)
            .UseIdentityColumn();

        builder.Property(e => e.CreatedAt)
            .IsRequired();

        builder.HasOne(e => e.IdClientNav)
            .WithMany(c => c.Sales)
            .HasForeignKey(e => e.IdClient)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("Client_Sale_FK");

        builder.HasOne(e => e.IdSubscriptionNav)
            .WithMany(s => s.Sales)
            .HasForeignKey(e => e.IdSubscription)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("Employee_Sale_FK");

        var sales = new List<Sale>
        {
            new()
            {
                IdSale = 1,
                IdClient = 1,
                IdSubscription = 1,
                CreatedAt = DateTime.Now
            },
            new()
            {
                IdSale = 2,
                IdClient = 2,
                IdSubscription = 2,
                CreatedAt = DateTime.Now
            },
            new()
            {
                IdSale = 3,
                IdClient = 3,
                IdSubscription = 3,
                CreatedAt = DateTime.Now
            }
        };

        builder.HasData(sales);
    }
}