using LegacyApp;
using LegacyApp.Interfaces;

namespace LegacyAppTest.TestDoubles;

public class FakeUserDataAccessAdapter : IUserDataAccessAdapter
{
    public void AddUser(User user)
    {
        Console.WriteLine($"Faked to add the user {user} successfully");
    }
}