using KolokwiumCF.Models;
using Microsoft.EntityFrameworkCore;

namespace KolokwiumCF.Repositories;

public class ClientRepository(KoloContext context) : IClientRepository
{
    public async Task<Client> GetClientAsync(int id)
    {
        return (await context.Clients
            .Include(c => c.Sales)
            .ThenInclude(s => s.IdSubscriptionNav)
            .ThenInclude(s => s.Payments)
            .FirstOrDefaultAsync(c => c.IdClient == id))!;
    }
}