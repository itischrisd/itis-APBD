using Microsoft.AspNetCore.Mvc;
using PrescriptionsApp.DTOs.Request;
using PrescriptionsApp.Services;

namespace PrescriptionsApp.Controllers;

[ApiController]
[Route("[controller]")]
public class PrescriptionController(IPrescriptionService prescriptionService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddPrescription([FromBody] PrescriptionCreateDTO request)
    {
        try
        {
            await prescriptionService.AddPrescriptionAsync(request);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}