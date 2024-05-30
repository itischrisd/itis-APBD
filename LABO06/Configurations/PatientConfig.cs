﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrescriptionsApp.Models;

namespace PrescriptionsApp.Configurations;

public class PatientConfig : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(e => e.IdPatient)
            .HasName("IdPatient_PK");

        builder.Property(e => e.IdPatient)
            .UseIdentityColumn();

        builder.Property(e => e.FirstName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.LastName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.BirthDate)
            .IsRequired();

        var patients = new List<Patient>
        {
            new()
            {
                IdPatient = 1,
                FirstName = "Jakub",
                LastName = "Nowak",
                BirthDate = DateTime.Now.AddYears(-25)
            },
            new()
            {
                IdPatient = 2,
                FirstName = "Michal",
                LastName = "Kowalski",
                BirthDate = DateTime.Now.AddYears(-21)
            },
            new()
            {
                IdPatient = 3,
                FirstName = "Patient",
                LastName = "Patientowich",
                BirthDate = DateTime.Now.AddYears(-27)
            },
            new()
            {
                IdPatient = 4,
                FirstName = "Sergio",
                LastName = "Kotowich",
                BirthDate = DateTime.Now.AddYears(-22)
            },
            new()
            {
                IdPatient = 5,
                FirstName = "Ala",
                LastName = "Peronska",
                BirthDate = DateTime.Now.AddYears(-50)
            },
            new()
            {
                IdPatient = 6,
                FirstName = "Kot",
                LastName = "Zygmund",
                BirthDate = DateTime.Now.AddYears(-29)
            },
            new()
            {
                IdPatient = 7,
                FirstName = "Natiel",
                LastName = "Patient",
                BirthDate = DateTime.Now.AddYears(-54)
            },
            new()
            {
                IdPatient = 8,
                FirstName = "Jas",
                LastName = "Profase",
                BirthDate = DateTime.Now.AddYears(-67)
            }
        };

        builder.HasData(patients);
    }
}