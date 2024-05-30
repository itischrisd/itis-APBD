using Microsoft.AspNetCore.Mvc;
using PrescriptionsApp.DTOs.Request;
using PrescriptionsApp.Services;

namespace PrescriptionsApp.Controllers;

[ApiController]
[Route("[controller]")]
public class PrescriptionController(IPrescriptionService prescriptionService) : Controller
{
    [HttpPost]
    public async Task<IActionResult> AddPrescription([FromBody] PrescriptionCreateDTO request)
    {
        try
        {
            await prescriptionService.AddPrescriptionAsync(request);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok();
    }
}