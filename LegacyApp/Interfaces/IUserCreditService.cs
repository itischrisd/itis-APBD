namespace LegacyApp.Interfaces;

public interface IUserCreditService
{
    int GetCreditLimit(string lastName);
}