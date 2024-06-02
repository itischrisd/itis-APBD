using Microsoft.AspNetCore.Mvc;
using PrescriptionsApp.Services;

namespace PrescriptionsApp.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientController(IPatientService patientService) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetPatient(int id)
    {
        try
        {
            var patient = await patientService.GetPatientAsync(id);
            return Ok(patient);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}