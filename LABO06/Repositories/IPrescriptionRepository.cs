using PrescriptionsApp.Models;

namespace PrescriptionsApp.Repositories;

public interface IPrescriptionRepository
{
    public Task<int> AddPrescriptionAsync(Prescription prescription);
    public Task<IEnumerable<Prescription>> GetPrescriptionsByPatientsIdAsync(int patientId);
}