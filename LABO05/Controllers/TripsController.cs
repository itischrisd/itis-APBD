using Microsoft.AspNetCore.Mvc;
using Zadanie7.Repositories;

namespace Zadanie7.Controllers;

[Route("api/trips")]
[ApiController]
public class TripsController(ITripsRepository tripsRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetTrips()
    {
        var trips = await tripsRepository.GetTripsAsync();
        return Ok(trips);
    }
}