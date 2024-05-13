using Microsoft.AspNetCore.Mvc;
using Zadanie7.Repositories;
using Zadanie7.Services;

namespace Zadanie7.Controllers;

[Route("api/trips")]
[ApiController]
public class TripsController(ITripsService tripsService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetTrips()
    {
        var trips = await tripsService.GetTripsAsync();
        return Ok(trips);
    }
}