using System;
using LegacyApp.Interfaces;
using LegacyApp.Validators.Users;

namespace LegacyApp
{
    public class UserService(
        IInputValidator inputValidator,
        IClientRepository clientRepository,
        IUserCreditService userCreditService,
        IUserDataAccessAdapter userDataAccessAdapter,
        ICreditValidator creditValidator)
    {
        [Obsolete("This is legacy constructor for backward compatibility. Use UserService(IInputValidator, IClientRepository, IUserCreditService) instead.")]
        public UserService() : this(new InputValidator(), new ClientRepository(), new UserCreditService(), new UserDataAccessAdapter(), new CreditValidator())
        {
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!ValidateInput(firstName, lastName, email, dateOfBirth))
            {
                return false;
            }

            var client = clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            switch (client.Type)
            {
                case "VeryImportantClient":
                    user.HasCreditLimit = false;
                    break;
                case "ImportantClient":
                {
                    var creditLimit = userCreditService.GetCreditLimit(user.LastName);
                    creditLimit = creditLimit * 2;
                    user.CreditLimit = creditLimit;

                    break;
                }
                default:
                {
                    user.HasCreditLimit = true;
                    var creditLimit = userCreditService.GetCreditLimit(user.LastName);
                    user.CreditLimit = creditLimit;

                    break;
                }
            }

            if (creditValidator.ValidateCreditLimit(user) == false)
            {
                return false;
            }

            userDataAccessAdapter.AddUser(user);

            return true;
        }

        private bool ValidateInput(string firstName, string lastName, string email, DateTime dateOfBirth)
        {
            return inputValidator.ValidateName(firstName, lastName) &&
                   inputValidator.ValidateEmail(email) &&
                   inputValidator.ValidateAge(dateOfBirth);
        }
    }
}
