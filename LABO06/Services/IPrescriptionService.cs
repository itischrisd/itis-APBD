using WebApplication1.DTOs.Command;

namespace WebApplication1.Services;

public interface IPrescriptionService
{
    public Task<int> AddPrescriptionAsync(PrescriptionMedicationCreateDTO request);
}