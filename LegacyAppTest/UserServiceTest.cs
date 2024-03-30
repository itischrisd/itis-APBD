using LegacyApp;
using LegacyApp.Validators.Users;
using LegacyAppTest.TestDoubles;

namespace LegacyAppTest;

public class UserServiceTest
{
    [Fact]
    public void AddUser_Should_Return_False_When_FirstName_Is_Empty()
    {
        var inputValidator = new InputValidator();
        var clientRepository = new FakeClientRepository();
        var userCreditService = new FakeUserCreditService();
        var userService = new UserService(inputValidator, clientRepository, userCreditService);
        const string firstName = "";
        const string lastName = "Kowalski";
        const string email = "test@mail.com";
        var dateOfBirth = new DateTime(1990, 1, 1);
        const int clientId = 1;

        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        Assert.False(result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_LastName_Is_Empty()
    {
        var inputValidator = new InputValidator();
        var clientRepository = new FakeClientRepository();
        var userCreditService = new FakeUserCreditService();
        var userService = new UserService(inputValidator, clientRepository, userCreditService);
        const string firstName = "Test";
        const string lastName = "";
        const string email = "test@mail.com";
        var dateOfBirth = new DateTime(1990, 1, 1);
        const int clientId = 1;

        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        Assert.False(result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_Email_Is_Invalid()
    {
        var inputValidator = new InputValidator();
        var clientRepository = new FakeClientRepository();
        var userCreditService = new FakeUserCreditService();
        var userService = new UserService(inputValidator, clientRepository, userCreditService);
        const string firstName = "Test";
        const string lastName = "Kowalski";
        const string email = "testmailcom";
        var dateOfBirth = new DateTime(1990, 1, 1);
        const int clientId = 1;

        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        Assert.False(result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_Age_Is_Less_Than_21()
    {
        var inputValidator = new InputValidator();
        var clientRepository = new FakeClientRepository();
        var userCreditService = new FakeUserCreditService();
        var userService = new UserService(inputValidator, clientRepository, userCreditService);
        const string firstName = "Test";
        const string lastName = "Kowalski";
        const string email = "test@mail.com";
        var dateOfBirth = new DateTime(2010, 1, 1);
        const int clientId = 1;

        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        Assert.False(result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_21st_Birthday_Is_Tomorrow()
    {
        var inputValidator = new InputValidator();
        var clientRepository = new FakeClientRepository();
        var userCreditService = new FakeUserCreditService();
        var userService = new UserService(inputValidator, clientRepository, userCreditService);
        const string firstName = "Test";
        const string lastName = "Kowalski";
        const string email = "test@mail.com";
        var dateOfBirth = DateTime.Now.AddYears(-21).AddDays(1);
        const int clientId = 1;

        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        Assert.False(result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_21st_Birthday_Is_Next_Month()
    {
        var inputValidator = new InputValidator();
        var clientRepository = new FakeClientRepository();
        var userCreditService = new FakeUserCreditService();
        var userService = new UserService(inputValidator, clientRepository, userCreditService);
        const string firstName = "Test";
        const string lastName = "Kowalski";
        const string email = "test@mail.com";
        var dateOfBirth = DateTime.Now.AddYears(-21).AddMonths(1);
        const int clientId = 1;

        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        Assert.False(result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_User_Has_Credit_Limit_Under_500()
    {
        var inputValidator = new StubInputValidator();
        var clientRepository = new FakeClientRepository();
        var userCreditService = new FakeUserCreditService();
        var userService = new UserService(inputValidator, clientRepository, userCreditService);
        const string firstName = "Test";
        const string lastName = "Testerski1";
        const string email = "test@mail.com";
        var dateOfBirth = new DateTime(1990, 1, 1);
        const int clientId = 1;

        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        Assert.False(result);
    }

    [Fact]
    public void AddUser_Should_Return_True_When_User_Is_Very_Important_Client()
    {
        var userService = new UserService();
        const string firstName = "Test";
        const string lastName = "Kowalski";
        const string email = "test@mail.com";
        var dateOfBirth = new DateTime(1990, 1, 1);
        const int clientId = 2;

        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        Assert.True(result);
    }

    [Fact]
    public void AddUser_Should_Return_True_When_User_Important_Client()
    {
        var userService = new UserService();
        const string firstName = "Test";
        const string lastName = "Kowalski";
        const string email = "test@mail.com";
        var dateOfBirth = new DateTime(1990, 1, 1);
        const int clientId = 3;

        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        Assert.True(result);
    }

    [Fact]
    public void AddUser_Should_Return_True_When_User_Normal_Client()
    {
        var userService = new UserService();
        const string firstName = "John";
        const string lastName = "Doe";
        const string email = "test@mail.com";
        var dateOfBirth = new DateTime(1990, 1, 1);
        const int clientId = 5;

        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        Assert.True(result);
    }

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