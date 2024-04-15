using LegacyApp;
using LegacyApp.Interfaces;

namespace LegacyAppTest.TestDoubles;

public class FakeClientRepository : IClientRepository
{
    private static readonly Dictionary<int, Client> Database = new()
    {
        {1, new Client{ClientId = 1, Name = "Testerski1", Address = "Warszawa, Testowa 1", Email = "test@mail.com", Type = "NormalClient"}},
        {2, new Client{ClientId = 2, Name = "Testerski2", Address = "Warszawa, Testowa 2", Email = "test@mail.com", Type = "ImportantClient"}},
        {3, new Client{ClientId = 3, Name = "Testerski3", Address = "Warszawa, Testowa 3", Email = "test@mail.com", Type = "VeryImportantClient"}}
    };

    public Client? GetById(int clientId)
    {
        return Database.GetValueOrDefault(clientId);
    }
}