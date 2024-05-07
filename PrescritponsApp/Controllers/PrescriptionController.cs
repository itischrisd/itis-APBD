using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PrescritponsApp.DTOs;
using PrescritponsApp.Services;

namespace PrescritponsApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrescriptionController(IPrescriptionService prescriptionService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetPrescriptions(string doctorLastName = null!)
    {
        var prescriptions = await prescriptionService.GetPrescriptions(doctorLastName);

        if (prescriptions.IsNullOrEmpty()) return NotFound("No prescriptions found");

        return Ok(prescriptions);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePrescription(PrescriptionCreationDto prescriptionCreationDto)
    {
        try
        {
            var createdPrescription = await prescriptionService.CreatePrescription(prescriptionCreationDto);
            return CreatedAtAction(nameof(CreatePrescription), createdPrescription);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}