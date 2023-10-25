using CRUD.WPF.Models;
using CRUD.WPF.Services;
using CRUD.WPF.Stores;
using CRUD.WPF.ViewModels.Dashboard;
using CRUD.WPF.ViewModels.Login;

namespace CRUD.WPF.Commands.Login
{
    public class LoginCommand : CommandBase
    {
        #region Fields
        private readonly NavigationService<DashboardViewModel> _navigationService;
        private readonly LoginViewModel _loginViewModel;
        private readonly AccountStore _accountStore;
        #endregion

        #region Contructor
        public LoginCommand(NavigationService<DashboardViewModel> navigationService, LoginViewModel loginViewModel, AccountStore accountStore)
        {
            _navigationService = navigationService;
            _loginViewModel = loginViewModel;
            _accountStore = accountStore;
        }
        #endregion

        #region CommandBase
        public override void Execute(object? parameter)
        {
            AccountModel accountModel = new AccountModel(_loginViewModel.Username, _loginViewModel.Password);
            _accountStore.CurrentAccount = accountModel;

            _navigationService.Navigate();
        }
        #endregion
    }
}
