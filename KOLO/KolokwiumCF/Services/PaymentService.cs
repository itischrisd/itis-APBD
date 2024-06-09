using KolokwiumCF.DTOs.Request;
using KolokwiumCF.Models;
using KolokwiumCF.Repositories;

namespace KolokwiumCF.Services;

public class PaymentService(IPaymentRepository paymentRepository, IClientRepository clientRepository) : IPaymentService
{
    public async Task<int> PayForSubscriptionAsync(PaymentDTO paymentDTO, int idSubscription, int idClient)
    {
        var client = await clientRepository.GetClientAsync(idClient);
        if (client == null) throw new Exception("Client not found");
        var subscription = client.Sales.Select(s => s.IdSubscriptionNav)
            .FirstOrDefault(s => s.IdSubscription == idSubscription);
        if (subscription == null) throw new Exception("Subscription not found");
        if (subscription.Payments.Sum(p => p.Amount) + paymentDTO.Amount > subscription.Price)
            throw new Exception("Payment amount exceeds subscription price");

        var payment = new Payment
        {
            Amount = paymentDTO.Amount,
            Date = paymentDTO.Date,
            IdSubscription = idSubscription,
            IdClient = idClient
        };

        return await paymentRepository.AddPaymentAsync(payment);
    }
}