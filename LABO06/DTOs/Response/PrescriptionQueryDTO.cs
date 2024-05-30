namespace PrescriptionsApp.DTOs.Response;

public class PrescriptionQueryDTO
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public IEnumerable<MedicamentQueryDTO> Medicaments { get; set; } = null!;
    public DoctorQueryDTO Doctor { get; set; } = null!;
}