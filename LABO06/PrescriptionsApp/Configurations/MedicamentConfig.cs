﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configurations;

public class MedicamentConfig : IEntityTypeConfiguration<Medicament>
{
    public void Configure(EntityTypeBuilder<Medicament> builder)
    {
        builder.HasKey(e => e.IdMedicament)
            .HasName("IdMedicament_PK");
        builder.Property(e => e.IdMedicament)
            .UseIdentityColumn();

        builder.Property(e => e.Name)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(e => e.Description)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(e => e.Type)
            .HasMaxLength(100)
            .IsRequired();

        // adding data

        var medicaments = new List<Medicament>
        {
            new()
            {
                IdMedicament = 1,
                Name = "Ibuprofène",
                Description = "Painkiller, 200mg 3 times a day.",
                Type = "Anti inflamatory pills"
            },
            new()
            {
                IdMedicament = 2,
                Name = "Happyness",
                Description = "From 10 to 1000 times a day.",
                Type = "Anti sadness pills"
            },
            new()
            {
                IdMedicament = 3,
                Name = "Sadness",
                Description = "CAN HARM YOUR HEALTH.",
                Type = "Anti happyness pills"
            }
        };

        builder.HasData(medicaments);
    }
}