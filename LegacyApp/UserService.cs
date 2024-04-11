using System;
using LegacyApp.Interfaces;

namespace LegacyApp
{
    public class UserService(
        IInputValidator inputValidator,
        IClientRepository clientRepository,
        IUserCreditService userCreditService,
        IUserDataAccessAdapter userDataAccessAdapter,
        ICreditValidator creditValidator)
    {
        [Obsolete("This is legacy constructor for backward compatibility. Use canonical constructor instead.")]
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
            var user =  CreateUser(firstName, lastName, email, dateOfBirth, client);

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

        private User CreateUser(string firstName, string lastName, string email, DateTime dateOfBirth, Client client)
        {

            var factory = IUserFactory.GetInstanceForTypeOrDefaultToNormal(client.Type);
            return factory.CreateUser(firstName, lastName, email, dateOfBirth, client, userCreditService);
        }
    }
}
