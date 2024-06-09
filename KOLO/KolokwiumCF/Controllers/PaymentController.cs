using KolokwiumCF.DTOs.Request;
using KolokwiumCF.Services;
using Microsoft.AspNetCore.Mvc;

namespace KolokwiumCF.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentController(IPaymentService paymentService) : ControllerBase
{
    [HttpPost("{idSubscription:int}/{idClient:int}")]
    public async Task<IActionResult> PayForSubscription(PaymentDTO paymentDTO, int idSubscription, int idClient)
    {
        try
        {
            var paymentId = await paymentService.PayForSubscriptionAsync(paymentDTO, idSubscription, idClient);
            return Ok(paymentId);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}