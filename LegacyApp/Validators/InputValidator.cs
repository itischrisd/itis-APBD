using System;
using LegacyApp.Interfaces;

namespace LegacyApp.Validators.Users;

public class InputValidator : IInputValidator
{
    public bool ValidateName(string firstName, string lastName)
    {
        return !(string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName));
    }

    public bool ValidateEmail(string email)
    {
        return email.Contains('@') || email.Contains('.');
    }

    public bool ValidateAge(DateTime dateOfBirth)
    {
        return DateTime.Now >= dateOfBirth.AddYears(21);
    }
}