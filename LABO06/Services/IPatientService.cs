using WebApplication1.DTOs.Query;

namespace WebApplication1.Services;

public interface IPatientService
{
    public Task<PatientQueryDTO> GetPatientAsync(int id);
}