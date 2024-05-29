using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configurations;

public class PrescriptionConfig : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder.HasKey(p => p.IdPrescription)
            .HasName("Prescription_PK");

        builder.Property(p => p.Date)
            .IsRequired();

        builder.Property(p => p.DueDate)
            .IsRequired();

        builder.HasOne(p => p.IdPatientNav)
            .WithMany(p => p.Prescriptions)
            .HasForeignKey(p => p.IdPatient)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("Patient_Prescription_FK");

        builder.HasOne(p => p.IdDoctorNav)
            .WithMany(d => d.Prescriptions)
            .HasForeignKey(p => p.IdDoctor)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("Doctor_Prescription_FK");

        builder.HasMany(p => p.PrescriptionMedicaments)
            .WithOne(pm => pm.IdPrescriptionNav)
            .HasForeignKey(pm => pm.IdPrescription)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("Prescription_PrescriptionMedicament_FK");

        var prescriptions = new List<Prescription>
        {
            new()
            {
                IdPrescription = 1,
                Date = DateTime.Now,
                DueDate = DateTime.Now.AddDays(30),
                IdDoctor = 1,
                IdPatient = 1
            },
            new()
            {
                IdPrescription = 2,
                Date = DateTime.Now,
                DueDate = DateTime.Now.AddDays(30),
                IdDoctor = 2,
                IdPatient = 2
            },
            new()
            {
                IdPrescription = 3,
                Date = DateTime.Now,
                DueDate = DateTime.Now.AddDays(30),
                IdDoctor = 3,
                IdPatient = 3
            }
        };

        builder.HasData(prescriptions);
    }
}