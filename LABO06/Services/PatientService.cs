using PrescriptionsApp.DTOs.Response;
using PrescriptionsApp.Repositories;

namespace PrescriptionsApp.Services;

public class PatientService(
    IPatientRepository patientRepository) : IPatientService
{
    public async Task<PatientQueryDTO> GetPatientAsync(int id)
    {
        var patient = await patientRepository.GetPatientAsync(id);

        if (patient == null) throw new Exception("Patient not found");

        var patientQueryDTO = new PatientQueryDTO
        {
            IdPatient = patient.IdPatient,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            BirthDate = patient.BirthDate,
            Prescriptions = patient.Prescriptions.OrderBy(p => p.DueDate)
                .Select(prescription => new PrescriptionQueryDTO
                {
                    IdPrescription = prescription.IdPrescription,
                    Date = prescription.Date,
                    DueDate = prescription.DueDate,
                    Medicaments = prescription.PrescriptionMedicaments.Select(prescriptionMedicament =>
                            new MedicamentQueryDTO
                            {
                                IdMedicament = prescriptionMedicament.IdMedicamentNav.IdMedicament,
                                Name = prescriptionMedicament.IdMedicamentNav.Name,
                                Dose = prescriptionMedicament.Dose,
                                Description = prescriptionMedicament.IdMedicamentNav.Description
                            })
                        .ToList(),
                    Doctor = new DoctorQueryDTO
                    {
                        IdDoctor = prescription.IdDoctorNav.IdDoctor,
                        FirstName = prescription.IdDoctorNav.FirstName
                    }
                })
                .ToList()
        };

        return patientQueryDTO;
    }
}