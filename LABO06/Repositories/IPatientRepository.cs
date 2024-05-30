using PrescriptionsApp.Models;

namespace PrescriptionsApp.Repositories;

public interface IPatientRepository
{
    public Task<Patient> GetPatientAsync(int id);
    public Task<int> AddPatientAsync(Patient patient);
}