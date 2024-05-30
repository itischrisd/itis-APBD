using PrescriptionsApp.DTOs.Response;

namespace PrescriptionsApp.Services;

public interface IPatientService
{
    public Task<PatientQueryDTO> GetPatientAsync(int id);
}