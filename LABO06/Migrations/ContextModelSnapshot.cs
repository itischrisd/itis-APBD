﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Models;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Models.Doctor", b =>
                {
                    b.Property<int>("IdDoctor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDoctor"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdDoctor")
                        .HasName("Doctor_PK");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            IdDoctor = 1,
                            Email = "SampleDoctor@gmail.com",
                            FirstName = "Sample",
                            LastName = "Doctor"
                        },
                        new
                        {
                            IdDoctor = 2,
                            Email = "JakubBiologist@gmail.com",
                            FirstName = "Jakub",
                            LastName = "Biologist"
                        },
                        new
                        {
                            IdDoctor = 3,
                            Email = "MichalPediatrician@gmail.com",
                            FirstName = "Michal",
                            LastName = "Pediatrician"
                        },
                        new
                        {
                            IdDoctor = 4,
                            Email = "SergioPsychiatrist@gmail.com",
                            FirstName = "Sergio",
                            LastName = "Psychiatrist"
                        },
                        new
                        {
                            IdDoctor = 5,
                            Email = "PabloAnesthesiologist@gmail.com",
                            FirstName = "Pablo",
                            LastName = "Anesthesiologist"
                        },
                        new
                        {
                            IdDoctor = 6,
                            Email = "AzucarDiabetes@gmail.com",
                            FirstName = "Azucar",
                            LastName = "Diabetes"
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Medicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMedicament"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdMedicament")
                        .HasName("IdMedicament_PK");

                    b.ToTable("Medicaments");

                    b.HasData(
                        new
                        {
                            IdMedicament = 1,
                            Description = "Painkiller, 200mg 3 times a day.",
                            Name = "Ibuprofène",
                            Type = "Anti inflamatory pills"
                        },
                        new
                        {
                            IdMedicament = 2,
                            Description = "From 10 to 1000 times a day.",
                            Name = "Happyness",
                            Type = "Anti sadness pills"
                        },
                        new
                        {
                            IdMedicament = 3,
                            Description = "CAN HARM YOUR HEALTH.",
                            Name = "Sadness",
                            Type = "Anti happyness pills"
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Patient", b =>
                {
                    b.Property<int>("IdPatient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPatient"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdPatient")
                        .HasName("IdPatient_PK");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            IdPatient = 1,
                            BirthDate = new DateTime(1999, 5, 29, 14, 41, 10, 48, DateTimeKind.Local).AddTicks(7321),
                            FirstName = "Jakub",
                            LastName = "Nowak"
                        },
                        new
                        {
                            IdPatient = 2,
                            BirthDate = new DateTime(2003, 5, 29, 14, 41, 10, 48, DateTimeKind.Local).AddTicks(7504),
                            FirstName = "Michal",
                            LastName = "Kowalski"
                        },
                        new
                        {
                            IdPatient = 3,
                            BirthDate = new DateTime(1997, 5, 29, 14, 41, 10, 48, DateTimeKind.Local).AddTicks(7510),
                            FirstName = "Patient",
                            LastName = "Patientowich"
                        },
                        new
                        {
                            IdPatient = 4,
                            BirthDate = new DateTime(2002, 5, 29, 14, 41, 10, 48, DateTimeKind.Local).AddTicks(7513),
                            FirstName = "Sergio",
                            LastName = "Kotowich"
                        },
                        new
                        {
                            IdPatient = 5,
                            BirthDate = new DateTime(1974, 5, 29, 14, 41, 10, 48, DateTimeKind.Local).AddTicks(7516),
                            FirstName = "Ala",
                            LastName = "Peronska"
                        },
                        new
                        {
                            IdPatient = 6,
                            BirthDate = new DateTime(1995, 5, 29, 14, 41, 10, 48, DateTimeKind.Local).AddTicks(7523),
                            FirstName = "Kot",
                            LastName = "Zygmund"
                        },
                        new
                        {
                            IdPatient = 7,
                            BirthDate = new DateTime(1970, 5, 29, 14, 41, 10, 48, DateTimeKind.Local).AddTicks(7525),
                            FirstName = "Natiel",
                            LastName = "Patient"
                        },
                        new
                        {
                            IdPatient = 8,
                            BirthDate = new DateTime(1957, 5, 29, 14, 41, 10, 48, DateTimeKind.Local).AddTicks(7528),
                            FirstName = "Jas",
                            LastName = "Profase"
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Prescription", b =>
                {
                    b.Property<int>("IdPrescription")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPrescription"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdDoctor")
                        .HasColumnType("int");

                    b.Property<int>("IdPatient")
                        .HasColumnType("int");

                    b.HasKey("IdPrescription")
                        .HasName("Prescription_PK");

                    b.HasIndex("IdDoctor");

                    b.HasIndex("IdPatient");

                    b.ToTable("Prescriptions");

                    b.HasData(
                        new
                        {
                            IdPrescription = 1,
                            Date = new DateTime(2024, 5, 29, 14, 41, 10, 52, DateTimeKind.Local).AddTicks(3244),
                            DueDate = new DateTime(2024, 6, 28, 14, 41, 10, 52, DateTimeKind.Local).AddTicks(3294),
                            IdDoctor = 1,
                            IdPatient = 1
                        },
                        new
                        {
                            IdPrescription = 2,
                            Date = new DateTime(2024, 5, 29, 14, 41, 10, 52, DateTimeKind.Local).AddTicks(3304),
                            DueDate = new DateTime(2024, 6, 28, 14, 41, 10, 52, DateTimeKind.Local).AddTicks(3305),
                            IdDoctor = 2,
                            IdPatient = 2
                        },
                        new
                        {
                            IdPrescription = 3,
                            Date = new DateTime(2024, 5, 29, 14, 41, 10, 52, DateTimeKind.Local).AddTicks(3308),
                            DueDate = new DateTime(2024, 6, 28, 14, 41, 10, 52, DateTimeKind.Local).AddTicks(3309),
                            IdDoctor = 3,
                            IdPatient = 3
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.PrescriptionMedicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .HasColumnType("int");

                    b.Property<int>("IdPrescription")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Dose")
                        .HasColumnType("int");

                    b.HasKey("IdMedicament", "IdPrescription")
                        .HasName("PrescriptionMedicamend_PK");

                    b.HasIndex("IdPrescription");

                    b.ToTable("Prescription_Medicament", (string)null);

                    b.HasData(
                        new
                        {
                            IdMedicament = 1,
                            IdPrescription = 1,
                            Details = "2 pills in am and pm",
                            Dose = 200
                        },
                        new
                        {
                            IdMedicament = 2,
                            IdPrescription = 1,
                            Details = "2 pills in am and pm",
                            Dose = 250
                        },
                        new
                        {
                            IdMedicament = 2,
                            IdPrescription = 2,
                            Details = "2 pills in am and pm",
                            Dose = 250
                        },
                        new
                        {
                            IdMedicament = 3,
                            IdPrescription = 3,
                            Details = "2 pills in am and pm",
                            Dose = 250
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Prescription", b =>
                {
                    b.HasOne("WebApplication1.Models.Doctor", "IdDoctorNav")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdDoctor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Doctor_Prescription_FK");

                    b.HasOne("WebApplication1.Models.Patient", "IdPatientNav")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdPatient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Patient_Prescription_FK");

                    b.Navigation("IdDoctorNav");

                    b.Navigation("IdPatientNav");
                });

            modelBuilder.Entity("WebApplication1.Models.PrescriptionMedicament", b =>
                {
                    b.HasOne("WebApplication1.Models.Medicament", "IdMedicamentNav")
                        .WithMany("PrescriptionMedicaments")
                        .HasForeignKey("IdMedicament")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Medicament_PrescriptionMedicament_FK");

                    b.HasOne("WebApplication1.Models.Prescription", "IdPrescriptionNav")
                        .WithMany("PrescriptionMedicaments")
                        .HasForeignKey("IdPrescription")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Prescription_PrescriptionMedicament_FK");

                    b.Navigation("IdMedicamentNav");

                    b.Navigation("IdPrescriptionNav");
                });

            modelBuilder.Entity("WebApplication1.Models.Doctor", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("WebApplication1.Models.Medicament", b =>
                {
                    b.Navigation("PrescriptionMedicaments");
                });

            modelBuilder.Entity("WebApplication1.Models.Patient", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("WebApplication1.Models.Prescription", b =>
                {
                    b.Navigation("PrescriptionMedicaments");
                });
#pragma warning restore 612, 618
        }
    }
}