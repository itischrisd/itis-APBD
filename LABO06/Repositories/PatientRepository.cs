using Microsoft.EntityFrameworkCore;
using PrescriptionsApp.Models;

namespace PrescriptionsApp.Repositories;

public class PatientRepository(Context context) : IPatientRepository
{
    public async Task<Patient> GetPatientAsync(int id)
    {
        return (await context.Patients.Include(p => p.Prescriptions)
            .ThenInclude(p => p.PrescriptionMedicaments)
            .ThenInclude(p => p.IdMedicamentNav)
            .Include(p => p.Prescriptions)
            .ThenInclude(p => p.IdDoctorNav)
            .FirstOrDefaultAsync(p => p.IdPatient == id))!;
    }
}