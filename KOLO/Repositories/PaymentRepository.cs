using KolokwiumCF.Models;

namespace KolokwiumCF.Repositories;

public class PaymentRepository(KoloContext context) : IPaymentRepository
{
    public async Task<int> AddPaymentAsync(Payment payment)
    {
        // await context.Patients.AddAsync(patient);
        // await context.SaveChangesAsync();
        // return patient.IdPatient;
        await context.Payments.AddAsync(payment);
        await context.SaveChangesAsync();
        return payment.IdPayment;
    }
}