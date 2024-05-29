using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs.Command;

public class PrescriptionMedicationCreateDTO
{
    [Required]
    public int IdMedicament { get; set; }

    [Range(1, int.MaxValue)]
    public int Dose { get; set; }

    [Required]
    [MaxLength(100)]
    public string Description { get; set; } = null!;
}