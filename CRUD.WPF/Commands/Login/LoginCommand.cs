using CRUD.WPF.Services;
using CRUD.WPF.ViewModels.Dashboard;
using CRUD.WPF.ViewModels.Login;
using System.Windows;

namespace CRUD.WPF.Commands.Login
{
    public class LoginCommand : CommandBase
    {
        #region Fields
        private readonly NavigationService<DashboardViewModel> _navigationService;
        private readonly LoginViewModel _loginViewModel;
        #endregion

        #region Contructor
        public LoginCommand(NavigationService<DashboardViewModel> navigationService, LoginViewModel loginViewModel)
        {
            _navigationService = navigationService;
            _loginViewModel = loginViewModel;
        }
        #endregion

        #region CommandBase
        public override void Execute(object? parameter)
        {
            MessageBox.Show($"Logging in {_loginViewModel.Username?? "moriarity99"}...");

            _navigationService.Navigate();
        }
        #endregion
    }
}
