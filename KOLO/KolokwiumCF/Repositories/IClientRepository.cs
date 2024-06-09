using KolokwiumCF.Models;

namespace KolokwiumCF.Repositories;

public interface IClientRepository
{
    Task<Client> GetClientAsync(int id);
}