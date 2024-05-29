using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs.Command;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class PrescriptionController(IPrescriptionService prescriptionService) : Controller
{
    [HttpPost]
    public async Task<IActionResult> AddPrescription([FromBody] PrescriptionMedicationCreateDTO request)
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