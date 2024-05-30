using Microsoft.EntityFrameworkCore;
using PrescriptionsApp.Models;

namespace PrescriptionsApp.Repositories;

public class PrescriptionRepository(Context context) : IPrescriptionRepository
{
    public async Task<int> AddPrescriptionAsync(Prescription prescription)
    {
        await context.Prescriptions.AddAsync(prescription);
        await context.SaveChangesAsync();
        return prescription.IdPrescription;
    }

    public async Task<IEnumerable<Prescription>> GetPrescriptionsByPatientsIdAsync(int patientId)
    {
        return await context.Prescriptions.Where(p => p.IdPatient == patientId)
            .Include(p => p.PrescriptionMedicaments)
            .ThenInclude(pm => pm.IdMedicamentNav)
            .ToListAsync();
    }
}