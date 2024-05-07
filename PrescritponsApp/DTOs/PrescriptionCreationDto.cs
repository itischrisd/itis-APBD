using System.ComponentModel.DataAnnotations;

namespace PrescritponsApp.DTOs;

public class PrescriptionCreationDto
{
    [Required] public DateTime Date { get; set; }

    [Required] public DateTime DueDate { get; set; }

    [Required] public int IdPatient { get; set; }

    [Required] public int IdDoctor { get; set; }
}