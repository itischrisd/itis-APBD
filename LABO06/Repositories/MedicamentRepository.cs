using PrescriptionsApp.Models;

namespace PrescriptionsApp.Repositories;

public class MedicamentRepository(Context context) : IMedicamentRepository
{
    public async Task<Medicament> GetMedicamentAsync(int id)
    {
        return (await context.Medicaments.FindAsync(id))!;
    }
}