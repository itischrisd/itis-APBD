using APBD_Zadanie_6.Models;
using APBD_Zadanie_6.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Zadanie_6.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WarehouseController(IWarehouseService warehouseService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddProduct(ProductWarehouseDTO productWarehouseDTO)
    {
        try
        {
            var idProductWarehouse = await warehouseService.AddProduct(productWarehouseDTO);
            return Ok(idProductWarehouse);
        }
        catch (Exception e)
        {
            return BadRequest(e.StackTrace);
        }
    }
}