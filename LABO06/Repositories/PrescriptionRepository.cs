using Microsoft.EntityFrameworkCore;
using PrescriptionsApp.Models;

namespace PrescriptionsApp.Repositories;

public class PrescriptionRepository(Context context) : IPrescriptionRepository
{
    public Task<int> AddPrescriptionAsync(Prescription prescription)
    {
        return Task.FromResult(1);
    }

    public async Task<IEnumerable<Prescription>> GetPrescriptionsByPatientsIdAsync(int patientId)
    {
        return await context.Prescriptions.Where(p => p.IdPatient == patientId)
            .ToListAsync();
    }
}