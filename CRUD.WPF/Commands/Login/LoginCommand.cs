using CRUD.Domain.Models;
using CRUD.WPF.Services;
using CRUD.WPF.Stores.Accounts;
using CRUD.WPF.ViewModels.Login;
using System.Linq;
using System.Windows;

namespace CRUD.WPF.Commands.Login
{
    public class LoginCommand : CommandBase
    {
        #region Fields
        private readonly INavigationService _recordsNavigationService;
        private readonly LoginViewModel _loginViewModel;
        private readonly AccountStore _accountStore;
        private readonly AccountModelStore _accountModelStore;
        #endregion

        #region Contructor
        public LoginCommand(
            INavigationService recordsNavigationService, 
            LoginViewModel loginViewModel, 
            AccountStore accountStore,
            AccountModelStore accountModelStore)
        {
            _recordsNavigationService = recordsNavigationService;
            _loginViewModel = loginViewModel;
            _accountStore = accountStore;
            _accountModelStore = accountModelStore;
        }
        #endregion

        #region CommandBase
        public override void Execute(object? parameter)
        {
            AccountModel accountModel = _accountModelStore.AccountModel.FirstOrDefault(account =>
                account.Username == _loginViewModel.Username &&
                account.Password == _loginViewModel.Password);

            if (accountModel != null)
            {
                _accountStore.CurrentAccount = accountModel;
                _recordsNavigationService.Navigate();
            }
            else
            {
                MessageBox.Show("Wrong username or password!", "Login Authentication", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
