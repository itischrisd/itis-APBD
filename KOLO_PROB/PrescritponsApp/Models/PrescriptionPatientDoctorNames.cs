namespace PrescritponsApp.Models;

public class PrescriptionPatientDoctorNames
{
    public int IdPrescription { get; init; }
    public DateTime Date { get; init; }
    public DateTime DueDate { get; init; }
    public string PatientLastName { get; init; } = null!;
    public string DoctorLastName { get; init; } = null!;
}