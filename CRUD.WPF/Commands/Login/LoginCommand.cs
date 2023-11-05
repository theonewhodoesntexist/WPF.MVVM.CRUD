using CRUD.WPF.Models;
using CRUD.WPF.Services;
using CRUD.WPF.Stores;
using CRUD.WPF.ViewModels.Dashboard;
using CRUD.WPF.ViewModels.Login;
using CRUD.WPF.ViewModels.Records;
using System.Windows;

namespace CRUD.WPF.Commands.Login
{
    public class LoginCommand : CommandBase
    {
        #region Fields
        private readonly INavigationService _recordsNavigationService;
        private readonly LoginViewModel _loginViewModel;
        private readonly AccountStore _accountStore;
        #endregion

        #region Contructor
        public LoginCommand(INavigationService recordsNavigationService, LoginViewModel loginViewModel, AccountStore accountStore)
        {
            _recordsNavigationService = recordsNavigationService;
            _loginViewModel = loginViewModel;
            _accountStore = accountStore;
        }
        #endregion

        #region CommandBase
        public override void Execute(object? parameter)
        {
            if (_loginViewModel.Username == "99" && _loginViewModel.Password == "99")
            {
                AccountModel accountModel = new AccountModel("moriarity99", "99", "Jim", "Moriarity");
                _accountStore.CurrentAccount = accountModel;
            }
            else
            {
                MessageBox.Show("Wrong username or password!", "Login Authentication", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _recordsNavigationService.Navigate();
        }
        #endregion
    }
}
