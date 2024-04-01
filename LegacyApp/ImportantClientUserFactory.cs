using System;
using LegacyApp.Interfaces;

namespace LegacyApp;

public class ImportantClientUserFactory : IUserFactory
{
    private static ImportantClientUserFactory _instance;

    private ImportantClientUserFactory() { }

    public static ImportantClientUserFactory Instance
    {
        get { return _instance ??= new ImportantClientUserFactory(); }
    }

    public User CreateUser(string firstName, string lastName, string email, DateTime dateOfBirth, Client client, IUserCreditService userCreditService)
    {
        var user = new User
        {
            Client = client,
            DateOfBirth = dateOfBirth,
            EmailAddress = email,
            FirstName = firstName,
            LastName = lastName,
            CreditLimit = userCreditService.GetCreditLimit(lastName) * 2
        };

        return user;
    }
}