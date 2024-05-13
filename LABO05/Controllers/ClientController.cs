using Microsoft.AspNetCore.Mvc;

namespace Zadanie7.Controllers;

[Route("api/clients")]
[ApiController]
public class ClientController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetClients()
    {
        return Ok();
    }
}