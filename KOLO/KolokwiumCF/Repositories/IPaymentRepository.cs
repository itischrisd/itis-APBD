using KolokwiumCF.Models;

namespace KolokwiumCF.Repositories;

public interface IPaymentRepository
{
    Task<int> AddPaymentAsync(Payment payment);
}