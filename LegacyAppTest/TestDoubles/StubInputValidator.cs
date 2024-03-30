using LegacyApp.Interfaces;

namespace LegacyAppTest.TestDoubles;

public class StubInputValidator : IInputValidator
{
    public bool ValidateAge(DateTime dateOfBirth)
    {
        return true;
    }

    public bool ValidateEmail(string email)
    {
        return true;
    }

    public bool ValidateName(string firstName, string lastName)
    {
        return true;
    }
}