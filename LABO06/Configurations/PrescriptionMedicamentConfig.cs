using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrescriptionsApp.Models;

namespace PrescriptionsApp.Configurations;

public class PrescriptionMedicamentConfig : IEntityTypeConfiguration<PrescriptionMedicament>
{
    public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
    {
        builder.HasKey(e => new
            {
                e.IdMedicament,
                e.IdPrescription
            })
            .HasName("PrescriptionMedicamend_PK");

        builder.ToTable("Prescription_Medicament");

        builder.Property(e => e.Dose);

        builder.Property(e => e.Details)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasOne(e => e.IdMedicamentNav)
            .WithMany(e => e.PrescriptionMedicaments)
            .HasForeignKey(e => e.IdMedicament)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("Medicament_PrescriptionMedicament_FK");

        builder.HasOne(e => e.IdPrescriptionNav)
            .WithMany(e => e.PrescriptionMedicaments)
            .HasForeignKey(e => e.IdPrescription)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("Prescription_PrescriptionMedicament_FK");

        var list = new List<PrescriptionMedicament>
        {
            new()
            {
                IdMedicament = 1,
                IdPrescription = 1,
                Dose = 200,
                Details = "2 pills in am and pm"
            },
            new()
            {
                IdMedicament = 2,
                IdPrescription = 1,
                Dose = 250,
                Details = "2 pills in am and pm"
            },
            new()
            {
                IdMedicament = 2,
                IdPrescription = 2,
                Dose = 250,
                Details = "2 pills in am and pm"
            },
            new()
            {
                IdMedicament = 3,
                IdPrescription = 3,
                Dose = 250,
                Details = "2 pills in am and pm"
            }
        };

        builder.HasData(list);
    }
}