using PrescriptionsApp.Models;

namespace PrescriptionsApp.Repositories;

public interface IMedicamentRepository
{
    public Task<Medicament> GetMedicamentAsync(int id);
}