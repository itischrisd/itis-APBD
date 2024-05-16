using PrescritponsApp.DTOs;
using PrescritponsApp.Models;
using PrescritponsApp.Repositories;

namespace PrescritponsApp.Services;

public class PrescriptionService(IPrescriptionRepository prescriptionRepository) : IPrescriptionService
{
    public async Task<IEnumerable<PrescriptionDto>> GetPrescriptions(string doctorLastName)
    {
        IEnumerable<PrescriptionPatientDoctorNames> prescriptions;

        if (doctorLastName != null)
            prescriptions = await prescriptionRepository.GetPrescriptions(doctorLastName);
        else
            prescriptions = await prescriptionRepository.GetPrescriptions();

        return prescriptions.Select(p => new PrescriptionDto
        {
            IdPrescription = p.IdPrescription,
            Date = p.Date,
            DueDate = p.DueDate,
            PatientLastName = p.PatientLastName,
            DoctorLastName = p.DoctorLastName
        });
    }

    public async Task<PrescriptionCreationConfirmationDto> CreatePrescription(
        PrescriptionCreationDto prescriptionCreationDto)
    {
        if (prescriptionCreationDto.DueDate < prescriptionCreationDto.Date)
            throw new Exception("DueDate cannot be before Date");

        var prescription = new Prescription
        {
            IdPatient = prescriptionCreationDto.IdPatient,
            IdDoctor = prescriptionCreationDto.IdDoctor,
            Date = prescriptionCreationDto.Date,
            DueDate = prescriptionCreationDto.DueDate
        };

        var createdPrescription = await prescriptionRepository.CreatePrescription(prescription);

        return new PrescriptionCreationConfirmationDto
        {
            IdPrescription = createdPrescription.IdPrescription,
            Date = createdPrescription.Date,
            DueDate = createdPrescription.DueDate,
            IdPatient = createdPrescription.IdPatient,
            IdDoctor = createdPrescription.IdDoctor
        };
    }
}