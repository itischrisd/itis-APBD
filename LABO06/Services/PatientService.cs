using PrescriptionsApp.DTOs.Response;
using PrescriptionsApp.Repositories;

namespace PrescriptionsApp.Services;

public class PatientService(
    IPatientRepository patientRepository,
    IPrescriptionRepository prescriptionRepository,
    IDoctorRepository doctorRepository) : IPatientService
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
            BirthDate = patient.BirthDate
        };

        var prescriptions = await prescriptionRepository.GetPrescriptionsByPatientsIdAsync(id);
        prescriptions = prescriptions.OrderBy(p => p.DueDate);

        var prescriptionQueryDTOs = prescriptions.Select(p => new PrescriptionQueryDTO
            {
                IdPrescription = p.IdPrescription,
                Date = p.Date,
                DueDate = p.DueDate,
                Medicaments = p.PrescriptionMedicaments.Select(pm => new MedicamentQueryDTO
                    {
                        IdMedicament = pm.IdMedicamentNav.IdMedicament,
                        Name = pm.IdMedicamentNav.Name,
                        Dose = pm.Dose,
                        Description = pm.IdMedicamentNav.Description
                    })
                    .ToList()
            })
            .ToList();

        foreach (var prescription in prescriptionQueryDTOs)
        {
            var doctor = await doctorRepository.GetDoctorAsync(prescription.IdPrescription);
            prescription.Doctor = new DoctorQueryDTO
            {
                IdDoctor = doctor.IdDoctor,
                FirstName = doctor.FirstName
            };
        }

        patientQueryDTO.Prescriptions = prescriptionQueryDTOs;

        return patientQueryDTO;
    }
}