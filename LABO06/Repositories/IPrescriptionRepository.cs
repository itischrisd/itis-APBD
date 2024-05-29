using WebApplication1.Models;

namespace WebApplication1.Repositories;

public interface IPrescriptionRepository
{
    public Task<int> AddPrescriptionAsync(Prescription prescription);
}