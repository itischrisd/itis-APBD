using KolokwiumCF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KolokwiumCF.Configurations;

public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.HasKey(e => e.IdSubscription)
            .HasName("Subscription_PK");

        builder.Property(e => e.IdSubscription)
            .UseIdentityColumn();

        builder.Property(e => e.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.RenewalPeriod)
            .IsRequired();

        builder.Property(e => e.EndTime)
            .IsRequired();

        builder.Property(e => e.Price)
            .IsRequired();

        builder.HasMany(e => e.Sales)
            .WithOne(s => s.IdSubscriptionNav)
            .HasForeignKey(e => e.IdSubscription)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("Subscription_Sale_FK");

        builder.HasMany(e => e.Payments)
            .WithOne(p => p.IdSubscriptionNav)
            .HasForeignKey(e => e.IdSubscription)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("Subscription_Payment_FK");

        var subscriptions = new List<Subscription>
        {
            new()
            {
                IdSubscription = 1,
                Name = "Sample",
                RenewalPeriod = 5,
                EndTime = DateTime.Today.AddDays(5),
                Price = 100
            },
            new()
            {
                IdSubscription = 2,
                Name = "Jakub",
                RenewalPeriod = 10,
                EndTime = DateTime.Today.AddDays(10),
                Price = 200
            },
            new()
            {
                IdSubscription = 3,
                Name = "Michal",
                RenewalPeriod = 15,
                EndTime = DateTime.Today.AddDays(15),
                Price = 300
            }
        };

        builder.HasData(subscriptions);
    }
}