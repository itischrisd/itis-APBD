﻿using KolokwiumCF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KolokwiumCF.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(e => e.IdPayment)
            .HasName("Payment_PK");

        builder.Property(e => e.IdPayment)
            .UseIdentityColumn();

        builder.Property(e => e.Date)
            .IsRequired();

        builder.Property(e => e.Amount)
            .IsRequired();

        builder.HasOne(e => e.IdClientNav)
            .WithMany(c => c.Payments)
            .HasForeignKey(p => p.IdClient)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("Payment_Client_FK");

        builder.HasOne(p => p.IdSubscriptionNav)
            .WithMany(s => s.Payments)
            .HasForeignKey(p => p.IdSubscription)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("Subscription_Payment_FK");

        var payments = new List<Payment>
        {
            new()
            {
                IdPayment = 1,
                IdClient = 1,
                IdSubscription = 1,
                Date = DateTime.Now,
                Amount = 100
            },
            new()
            {
                IdPayment = 2,
                IdClient = 2,
                IdSubscription = 2,
                Date = DateTime.Now,
                Amount = 200
            },
            new()
            {
                IdPayment = 3,
                IdClient = 3,
                IdSubscription = 3,
                Date = DateTime.Now,
                Amount = 300
            }
        };

        builder.HasData(payments);
    }
}