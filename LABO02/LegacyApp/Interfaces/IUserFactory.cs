using System;

namespace LegacyApp.Interfaces;

public interface IUserFactory
{
    User CreateUser(string firstName, string lastName, string email, DateTime dateOfBirth, Client client, IUserCreditService userCreditService);

    static IUserFactory GetInstanceForTypeOrDefaultToNormal(string clientType)
    {
        IUserFactory factory;
        var factoryType = Type.GetType($"LegacyApp.{clientType}UserFactory");
        if (factoryType != null)
        {
            var factoryInstance = factoryType.GetProperty("Instance");
            if (factoryInstance != null)
            {
                factory = (IUserFactory)factoryInstance.GetValue(null);
            }
            else
            {
                factory = NormalClientUserFactory.Instance;
            }
        }
        else
        {
            factory = NormalClientUserFactory.Instance;
        }

        return factory;
    }
}