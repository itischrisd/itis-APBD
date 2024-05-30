using PrescriptionsApp.Models;

namespace PrescriptionsApp.Repositories;

public class DoctorRepository(Context context) : IDoctorRepository
{
    public async Task<Doctor> GetDoctorAsync(int id)
    {
        return (await context.Doctors.FindAsync(id))!;
    }
}