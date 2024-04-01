using LegacyApp;

namespace LegacyAppTest;

public class UserServiceIntegrationTests
{
    [Fact]
    public void AddUser_Should_Throw_Exception_When_Client_Does_Not_Exist()
    {
        var userService = new UserService();
        const string firstName = "Test";
        const string lastName = "Kowalski";
        const string email = "test@mail.com";
        var dateOfBirth = new DateTime(1990, 1, 1);
        const int clientId = 7;

        Assert.Throws<ArgumentException>(() => userService.AddUser(firstName, lastName, email, dateOfBirth, clientId));
    }

    [Fact]
    public void AddUser_Should_Throw_Exception_When_Client_Credit_Does_Not_Exist()
    {
        var userService = new UserService();
        const string firstName = "Test";
        const string lastName = "Radziwiłł";
        const string email = "test@mail.com";
        var dateOfBirth = new DateTime(1990, 1, 1);
        const int clientId = 1;

        Assert.Throws<ArgumentException>(() => userService.AddUser(firstName, lastName, email, dateOfBirth, clientId));
    }
}