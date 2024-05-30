using PrescriptionsApp.DTOs.Request;
using PrescriptionsApp.Models;
using PrescriptionsApp.Repositories;

namespace PrescriptionsApp.Services;

public class PrescriptionService(
    IPatientRepository patientRepository,
    IMedicamentRepository medicamentRepository,
    IPrescriptionRepository prescriptionRepository,
    IDoctorRepository doctorRepository)
    : IPrescriptionService
{
    public async Task<int> AddPrescriptionAsync(PrescriptionCreateDTO request)
    {
        var patientInRequest = request.Patient;
        var patientInDb = await patientRepository.GetPatientAsync(patientInRequest.IdPatient);

        if (patientInDb == null)
            await patientRepository.AddPatientAsync(new Patient
            {
                FirstName = patientInRequest.FirstName,
                LastName = patientInRequest.LastName,
                BirthDate = patientInRequest.BirthDate
            });
        else if (patientInRequest.FirstName != patientInDb.FirstName ||
                 patientInRequest.LastName != patientInDb.LastName ||
                 patientInRequest.BirthDate != patientInDb.BirthDate)
            throw new Exception("Patient data in request does not match patient data in database.");

        if (doctorRepository.GetDoctorAsync(request.IdDoctor) == null) throw new Exception("Doctor not found.");

        if (request.DueDate < request.Date) throw new Exception("Due date must be later than date.");

        if (request.Medicaments.Count() > 10) throw new Exception("Prescription must contain at least one medicament.");

        foreach (var medicament in request.Medicaments)
        {
            var medicamentInDb = await medicamentRepository.GetMedicamentAsync(medicament.IdMedicament);

            if (medicamentInDb == null) throw new Exception("Medicament not found.");
        }

        await prescriptionRepository.AddPrescriptionAsync(new Prescription
        {
            Date = request.Date,
            DueDate = request.DueDate,
            IdPatient = patientInRequest.IdPatient,
            IdDoctor = request.IdDoctor,
            PrescriptionMedicaments = request.Medicaments.Select(m => new PrescriptionMedicament
                {
                    IdMedicament = m.IdMedicament,
                    Dose = m.Dose,
                    Details = m.Description
                })
                .ToList()
        });

        return 0;
    }
}