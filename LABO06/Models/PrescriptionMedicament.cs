namespace WebApplication1.Models;

public class PrescriptionMedicament
{
    public int IdMedicament { get; set; }
    public int IdPrescription { get; set; }
    public int? Dose { get; set; }
    public string Details { get; set; } = null!;

    public virtual Medicament IdMedicamentNav { get; set; } = null!;
    public virtual Prescription IdPrescriptionNav { get; set; } = null!;
}