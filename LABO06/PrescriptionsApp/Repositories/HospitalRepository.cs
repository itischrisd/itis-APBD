using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Repositories;

public class HospitalRepository(Context context) : IHospitalRepository
{
    public Task<string> AddDoctorAsync(DoctorDTO doctor)
    {
        throw new NotImplementedException();
    }

    public async Task<string> AddPrescriptionAsync(PrescriptionRequestDTO request)
    {
        await context.Prescriptions.AddAsync(new Prescription
        {
            Date = DateTime.Now,
            DueDate = request.DueDate,
            IdDoctor = 1,
            IdPatient = 1
        });
        await context.SaveChangesAsync();
        return "ok";
    }
}