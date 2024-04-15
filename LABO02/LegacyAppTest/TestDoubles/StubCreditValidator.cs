using LegacyApp;
using LegacyApp.Interfaces;

namespace LegacyAppTest.TestDoubles;

public class StubCreditValidator : ICreditValidator
{
    public bool ValidateCreditLimit(User user)
    {
        return true;
    }
}