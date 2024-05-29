namespace WebApplication1.DTOs.Query;

public class PatientQueryDTO
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public IEquatable<PrescriptionQueryDTO> Prescriptions { get; set; } = null!;
}