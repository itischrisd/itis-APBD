using KolokwiumCF.DTOs.Request;
using KolokwiumCF.DTOs.Response;
using KolokwiumCF.Models;
using KolokwiumCF.Repositories;

namespace KolokwiumCF.Services;

public class ClientService(IClientRepository clientRepository, IPaymentRepository paymentRepository) : IClientService
{
    public async Task<ClientDTO> GetClientAsync(int id)
    {
        var client = await clientRepository.GetClientAsync(id);
        if (client == null) throw new Exception("Client not found");
        return new ClientDTO
        {
            FirstName = client.FirstName,
            LastName = client.LastName,
            Email = client.Email,
            Phone = client.Phone,
            Discount = client.Discounts.Where(d => d.DateFrom < DateTime.Now && d.DateTo > DateTime.Now)
                .Select(d => d.Value)
                .FirstOrDefault(),
            Subscriptions = client.Sales.Select(s => s.IdSubscriptionNav)
                .Select(s => new SubscriptionDTO
                {
                    IdSubscription = s.IdSubscription,
                    Name = s.Name,
                    RenewalPeriod = s.RenewalPeriod,
                    TotalPaidAmount = s.Payments.Sum(p => p.Amount)
                })
                .ToList()
        };
    }
}