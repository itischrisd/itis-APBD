using KolokwiumCF.DTOs.Request;
using KolokwiumCF.DTOs.Response;

namespace KolokwiumCF.Services;

public interface IClientService
{
    Task<ClientDTO> GetClientAsync(int id);
}