using PrescriptionsApp.Models;

namespace PrescriptionsApp.Repositories;

public class PatientRepository(Context context) : IPatientRepository
{
    public async Task<Patient> GetPatientAsync(int id)
    {
        return (await context.Patients.FindAsync(id))!;
    }

    public async Task<int> AddPatientAsync(Patient patient)
    {
        await context.Patients.AddAsync(patient);
        await context.SaveChangesAsync();
        return patient.IdPatient;
    }
}