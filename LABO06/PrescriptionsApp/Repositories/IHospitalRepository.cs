using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Repositories;

public interface IHospitalRepository
{
    public Task<string> AddDoctorAsync(DoctorDTO doctor);
    public Task<string> AddPrescriptionAsync(PrescriptionRequestDTO request);
}