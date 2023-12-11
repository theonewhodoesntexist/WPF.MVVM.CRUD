using CRUD.WPF.Stores.Accounts;
using CRUD.WPF.ViewModels.Login;
using System;
using System.Threading.Tasks;

namespace CRUD.WPF.Commands.Accounts
{
    public class LoadAccountCommand : AsyncCommandBase
    {
        #region Fields
        private readonly AccountModelStore _accountModelStore;
        private readonly LoginViewModel _loginViewModel;
        #endregion

        #region Constructor
        public LoadAccountCommand(AccountModelStore accountModelStore, LoginViewModel loginViewModel)
        {
            _accountModelStore = accountModelStore;
            _loginViewModel = loginViewModel;
        }
        #endregion

        #region AsyncCommandBase
        public async override Task ExecuteAsync(object? parameter)
        {
            _loginViewModel.ErrorMessage = null;
            _loginViewModel.IsLoading = true;

            try
            {
                await _accountModelStore.Load();
            }
            catch (Exception)
            {
                _loginViewModel.ErrorMessage = "Failed to fetch Account!";
            }
            finally 
            {
                _loginViewModel.IsLoading = false;
            }
        }
        #endregion
    }
}
