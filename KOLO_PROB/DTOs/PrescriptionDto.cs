namespace PrescritponsApp.DTOs;

public class PrescriptionDto
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public string PatientLastName { get; set; } = null!;
    public string DoctorLastName { get; set; } = null!;
}