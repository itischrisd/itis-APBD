using LegacyApp.Interfaces;

namespace LegacyApp;

public class CreditValidator : ICreditValidator
{
    public bool ValidateCreditLimit(User user)
    {
        return user.CreditLimit >= 500 || !user.HasCreditLimit;
    }
}