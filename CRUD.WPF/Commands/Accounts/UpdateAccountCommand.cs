using CRUD.Domain.Models;
using CRUD.WPF.Services;
using CRUD.WPF.Stores.Accounts;
using CRUD.WPF.ViewModels.Account;
using System;
using System.Threading.Tasks;

namespace CRUD.WPF.Commands.Accounts
{
    public class UpdateAccountCommand : AsyncCommandBase
    {
        #region Fields
        private readonly AccountModelStore _accountModelStore;
        private readonly INavigationService _closeModalNavigationService;
        private readonly UpdateAccountViewModel _updateAccountViewModel;
        #endregion

        #region Constructor
        public UpdateAccountCommand(
            AccountModelStore accountModelStore, 
            INavigationService closeModalNavigationService, 
            UpdateAccountViewModel updateAccountViewModel)
        {
            _accountModelStore = accountModelStore;
            _closeModalNavigationService = closeModalNavigationService;
            _updateAccountViewModel = updateAccountViewModel;
        }
        #endregion

        #region AsyncCommandBase
        public override async Task ExecuteAsync(object? parameter)
        {
            UpdateAccountViewModel account = _updateAccountViewModel;

            AccountModel accountModel = new AccountModel(
                account.Username,
                account.Password,
                account.FirstName,
                account.LastName);

            try
            {
                await _accountModelStore.Update(accountModel);

                _closeModalNavigationService.Navigate();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
