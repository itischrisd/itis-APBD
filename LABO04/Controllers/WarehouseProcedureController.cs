using APBD_Zadanie_6.Models;
using APBD_Zadanie_6.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Zadanie_6.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WarehouseProcedureController(IWarehouseService warehouseService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddProduct(ProductWarehouseDTO productWarehouseDTO)
    {
        try
        {
            var idProductWarehouse = await warehouseService.AddProductByProcedure(productWarehouseDTO);
            return Ok(idProductWarehouse);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}