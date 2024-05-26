using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class HospitalController(IHospitalRepository hospitalRepository) : Controller
{
    [HttpPost]
    public IActionResult AddDoctor([FromBody] DoctorDTO doctor)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddPrescription([FromBody] PrescriptionRequestDTO request)
    {
        await hospitalRepository.AddPrescriptionAsync(request);
        return Ok();
    }
}