using PrescriptionsApp.DTOs.Request;

namespace PrescriptionsApp.Services;

public interface IPrescriptionService
{
    public Task<int> AddPrescriptionAsync(PrescriptionCreateDTO request);
}