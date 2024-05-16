using PrescritponsApp.Models;

namespace PrescritponsApp.Repositories;

public interface IPrescriptionRepository
{
    Task<IEnumerable<PrescriptionPatientDoctorNames>> GetPrescriptions();
    Task<IEnumerable<PrescriptionPatientDoctorNames>> GetPrescriptions(string doctorLastName);
    Task<Prescription> CreatePrescription(Prescription prescription);
}