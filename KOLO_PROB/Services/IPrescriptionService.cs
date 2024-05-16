using PrescritponsApp.DTOs;

namespace PrescritponsApp.Services;

public interface IPrescriptionService
{
    public Task<IEnumerable<PrescriptionDto>> GetPrescriptions(string doctorLastName);

    public Task<PrescriptionCreationConfirmationDto>
        CreatePrescription(PrescriptionCreationDto prescriptionCreationDto);
}