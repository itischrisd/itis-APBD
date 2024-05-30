using PrescriptionsApp.Models;

namespace PrescriptionsApp.Repositories;

public interface IDoctorRepository
{
    public Task<Doctor> GetDoctorAsync(int id);
}