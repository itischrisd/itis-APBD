namespace LegacyApp.Interfaces;

public interface ICreditValidator
{
    bool ValidateCreditLimit(User user);
}