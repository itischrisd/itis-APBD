using System;
using LegacyApp.Interfaces;
using LegacyApp.Validators.Users;

namespace LegacyApp
{
    public class UserService
    {
        private readonly IInputValidator _inputValidator;
        private readonly IClientRepository _clientRepository;
        private readonly IUserCreditService _userCreditService;

        [Obsolete("This is legacy constructor for backward compatibility. Use UserService(IInputValidator, IClientRepository, IUserCreditService) instead.")]
        public UserService()
        {
            _inputValidator = new InputValidator();
            _clientRepository = new ClientRepository();
            _userCreditService = new UserCreditService();
        }

        public UserService(IInputValidator inputValidator, IClientRepository clientRepository, IUserCreditService userCreditService)
        {
            _inputValidator = inputValidator;
            _clientRepository = clientRepository;
            _userCreditService = userCreditService;
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!ValidateInput(firstName, lastName, email, dateOfBirth))
            {
                return false;
            }

            var client = _clientRepository.GetById(clientId);

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
                    var creditLimit = _userCreditService.GetCreditLimit(user.LastName);
                    creditLimit = creditLimit * 2;
                    user.CreditLimit = creditLimit;

                    break;
                }
                default:
                {
                    user.HasCreditLimit = true;
                    var creditLimit = _userCreditService.GetCreditLimit(user.LastName);
                    user.CreditLimit = creditLimit;

                    break;
                }
            }

            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }

        private bool ValidateInput(string firstName, string lastName, string email, DateTime dateOfBirth)
        {
            return _inputValidator.ValidateName(firstName, lastName) &&
                   _inputValidator.ValidateEmail(email) &&
                   _inputValidator.ValidateAge(dateOfBirth);
        }
    }
}
