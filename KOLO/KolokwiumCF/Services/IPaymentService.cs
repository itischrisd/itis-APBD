using KolokwiumCF.DTOs.Request;

namespace KolokwiumCF.Services;

public interface IPaymentService
{
    Task<int> PayForSubscriptionAsync(PaymentDTO paymentDTO, int idSubscription, int idClient);
}