using System;
using LegacyApp.Interfaces;

namespace LegacyApp;

public class VeryImportantClientUserFactory : IUserFactory
{
    private static VeryImportantClientUserFactory _instance;

    private VeryImportantClientUserFactory() { }

    public static VeryImportantClientUserFactory Instance
    {
        get { return _instance ??= new VeryImportantClientUserFactory(); }
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
            HasCreditLimit = false
        };

        return user;
    }
}