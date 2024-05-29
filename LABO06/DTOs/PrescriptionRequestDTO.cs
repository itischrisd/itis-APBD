using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs;

public class PrescriptionRequestDTO
{
    [Required]
    public PatientDTO Patient { get; set; } = null!;
    public List<MedicamentDTO> Medicaments { get; set; } = [];
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
}