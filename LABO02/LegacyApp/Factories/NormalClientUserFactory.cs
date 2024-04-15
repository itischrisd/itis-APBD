using System;
using LegacyApp.Interfaces;

namespace LegacyApp;

public class NormalClientUserFactory : IUserFactory
{
    private static NormalClientUserFactory _instance;

    private NormalClientUserFactory() { }

    public static NormalClientUserFactory Instance
    {
        get { return _instance ??= new NormalClientUserFactory(); }
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
            HasCreditLimit = true,
            CreditLimit = userCreditService.GetCreditLimit(lastName)
        };

        return user;
    }
}