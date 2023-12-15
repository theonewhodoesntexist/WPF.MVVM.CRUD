using CRUD.Domain.Models;
using CRUD.WPF.Stores.Accounts;
using CRUD.WPF.ViewModels.Login;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.WPF.Commands.Accounts
{
    public class CreateAccountCommand : AsyncCommandBase
    {
        #region Fields
        private readonly AccountModelStore _accountModelStore;
        private readonly LoginViewModel _loginViewModel;
        #endregion

        #region Constructor
        public CreateAccountCommand(AccountModelStore accountModelStore, LoginViewModel loginViewModel)
        {
            _accountModelStore = accountModelStore;
            _loginViewModel = loginViewModel;
        }
        #endregion

        #region AsyncCommandBase
        public async override Task ExecuteAsync(object? parameter)
        {
            int count = _accountModelStore.AccountModel.Count();

            if(count >= 1)
            {
                return;
            }

            _loginViewModel.ErrorMessage = null;
            _loginViewModel.IsLoading = true;

            AccountModel accountModel = new AccountModel(Guid.NewGuid(), "99", "99", "Johan", "Liebert");

            try
            {
                await _accountModelStore.Create(accountModel);
            }
            catch (Exception)
            {
                _loginViewModel.ErrorMessage = "Failed to create Account!";
            }
            finally
            {
                _loginViewModel.IsLoading = false;
            }
        }
        #endregion
    }
}
