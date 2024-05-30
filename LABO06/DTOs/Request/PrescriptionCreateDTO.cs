using System.ComponentModel.DataAnnotations;

namespace PrescriptionsApp.DTOs.Request;

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

    [Required]
    public int IdDoctor { get; set; }
}