using LegacyApp.Interfaces;

namespace LegacyAppTest.TestDoubles;

public class FakeUserCreditService : IUserCreditService
{
    private readonly Dictionary<string, int> _database = new()
    {
        {"Testerski1", 200},
        {"Testerski2", 20000},
        {"Testerski3", 10000}
    };

    public int GetCreditLimit(string lastName)
    {
        return _database.GetValueOrDefault(lastName, 0);
    }
}