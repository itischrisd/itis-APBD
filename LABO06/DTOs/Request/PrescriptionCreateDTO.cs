﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs.Command;

public class PrescriptionCreateDTO
{
    [Required]
    public PatientCreateDTO Patient { get; set; } = null!;

    [Required]
    public IEnumerable<PrescriptionMedicationCreateDTO> Medicaments { get; set; } = null!;

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public DateTime DueDate { get; set; }
}