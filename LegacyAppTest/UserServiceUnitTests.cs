using LegacyApp;
using LegacyAppTest.TestDoubles;

namespace LegacyAppTest;

public class UserServiceUnitTests
{
    [Fact]
    public void AddUser_Should_Return_False_When_FirstName_Is_Empty()
    {
        var inputValidator = new InputValidator();
        var clientRepository = new FakeClientRepository();
        var userCreditService = new FakeUserCreditService();
        var userDataAccessAdapter = new FakeUserDataAccessAdapter();
        var creditValidator = new CreditValidator();
        var userService = new UserService(inputValidator, clientRepository, userCreditService, userDataAccessAdapter, creditValidator);
        const string firstName = "";
        const string lastName = "Testerski";
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
        var userDataAccessAdapter = new FakeUserDataAccessAdapter();
        var creditValidator = new CreditValidator();
        var userService = new UserService(inputValidator, clientRepository, userCreditService, userDataAccessAdapter, creditValidator);
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
        var userDataAccessAdapter = new FakeUserDataAccessAdapter();
        var creditValidator = new CreditValidator();
        var userService = new UserService(inputValidator, clientRepository, userCreditService, userDataAccessAdapter, creditValidator);
        const string firstName = "Test";
        const string lastName = "Testerski";
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
        var userDataAccessAdapter = new FakeUserDataAccessAdapter();
        var creditValidator = new CreditValidator();
        var userService = new UserService(inputValidator, clientRepository, userCreditService, userDataAccessAdapter, creditValidator);
        const string firstName = "Test";
        const string lastName = "Testerski";
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
        var userDataAccessAdapter = new FakeUserDataAccessAdapter();
        var creditValidator = new CreditValidator();
        var userService = new UserService(inputValidator, clientRepository, userCreditService, userDataAccessAdapter, creditValidator);
        const string firstName = "Test";
        const string lastName = "Testerski";
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
        var userDataAccessAdapter = new FakeUserDataAccessAdapter();
        var creditValidator = new CreditValidator();
        var userService = new UserService(inputValidator, clientRepository, userCreditService, userDataAccessAdapter, creditValidator);
        const string firstName = "Test";
        const string lastName = "Testerski";
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
        var userDataAccessAdapter = new FakeUserDataAccessAdapter();
        var creditValidator = new CreditValidator();
        var userService = new UserService(inputValidator, clientRepository, userCreditService, userDataAccessAdapter, creditValidator);
        const string firstName = "Test";
        const string lastName = "Testerski1";
        const string email = "test@mail.com";
        var dateOfBirth = new DateTime(1990, 1, 1);
        const int clientId = 1;

        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        Assert.False(result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_User_Is_Normal_Client_With_Credit_Below_500()
    {
        var inputValidator = new StubInputValidator();
        var clientRepository = new FakeClientRepository();
        var userCreditService = new FakeUserCreditService();
        var userDataAccessAdapter = new FakeUserDataAccessAdapter();
        var creditValidator = new CreditValidator();
        var userService = new UserService(inputValidator, clientRepository, userCreditService, userDataAccessAdapter, creditValidator);
        const string firstName = "Test";
        const string lastName = "Testerski1";
        const string email = "test@mail.com";
        var dateOfBirth = new DateTime(1990, 1, 1);
        const int clientId = 1;

        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        Assert.False(result);
    }

    [Fact]
    public void AddUser_Should_Return_True_When_User_Is_Normal_Client_With_Credit_Above_500()
    {
        var inputValidator = new StubInputValidator();
        var clientRepository = new FakeClientRepository();
        var userCreditService = new FakeUserCreditService();
        var userDataAccessAdapter = new FakeUserDataAccessAdapter();
        var creditValidator = new CreditValidator();
        var userService = new UserService(inputValidator, clientRepository, userCreditService, userDataAccessAdapter, creditValidator);
        const string firstName = "Test";
        const string lastName = "Testerski2";
        const string email = "test@mail.com";
        var dateOfBirth = new DateTime(1990, 1, 1);
        const int clientId = 1;

        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        Assert.True(result);
    }

    [Fact]
    public void AddUser_Should_Return_True_When_User_Is_Important_Client()
    {
        var inputValidator = new StubInputValidator();
        var clientRepository = new FakeClientRepository();
        var userCreditService = new FakeUserCreditService();
        var userDataAccessAdapter = new FakeUserDataAccessAdapter();
        var creditValidator = new CreditValidator();
        var userService = new UserService(inputValidator, clientRepository, userCreditService, userDataAccessAdapter, creditValidator);
        const string firstName = "Test";
        const string lastName = "Testerski";
        const string email = "test@mail.com";
        var dateOfBirth = new DateTime(1990, 1, 1);
        const int clientId = 2;

        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        Assert.True(result);
    }

    [Fact]
    public void AddUser_Should_Return_True_When_User_Is_Very_Important_Client_With_No_Credit()
    {
        var inputValidator = new StubInputValidator();
        var clientRepository = new FakeClientRepository();
        var userCreditService = new FakeUserCreditService();
        var userDataAccessAdapter = new FakeUserDataAccessAdapter();
        var creditValidator = new CreditValidator();
        var userService = new UserService(inputValidator, clientRepository, userCreditService, userDataAccessAdapter, creditValidator);
        const string firstName = "Test";
        const string lastName = "Testerski";
        const string email = "test@mail.com";
        var dateOfBirth = new DateTime(1990, 1, 1);
        const int clientId = 3;

        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        Assert.True(result);
    }
}