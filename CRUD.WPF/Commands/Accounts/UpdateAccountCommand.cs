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
            _updateAccountViewModel.ErrorMessage = null;
            _updateAccountViewModel.IsSubmitting = true;

            AccountModel accountModel = new AccountModel(
                _updateAccountViewModel.AccountModel.Id, 
                _updateAccountViewModel.Username,
                _updateAccountViewModel.Password,
                _updateAccountViewModel.FirstName,
                _updateAccountViewModel.LastName);

            try
            {
                await _accountModelStore.Update(accountModel);

                _closeModalNavigationService.Navigate();
            }
            catch (Exception)
            {
                _updateAccountViewModel.ErrorMessage = "Failed to update Account!";
            }
            finally
            {
                _updateAccountViewModel.IsSubmitting = false;
            }
        }
        #endregion
    }
}
