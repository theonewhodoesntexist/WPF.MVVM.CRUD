﻿using CRUD.WPF.Models;
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
        private readonly INavigationService<RecordsViewModel> _navigationService;
        private readonly LoginViewModel _loginViewModel;
        private readonly AccountStore _accountStore;
        #endregion

        #region Contructor
        public LoginCommand(INavigationService<RecordsViewModel> navigationService, LoginViewModel loginViewModel, AccountStore accountStore)
        {
            _navigationService = navigationService;
            _loginViewModel = loginViewModel;
            _accountStore = accountStore;
        }
        #endregion

        #region CommandBase
        public override void Execute(object? parameter)
        {
            if (_loginViewModel.Username != "99" && _loginViewModel.Password != "99")
            {
                MessageBox.Show("Wrong username or password!", "Login Authentication", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            AccountModel accountModel = new AccountModel("moriarity99", "99", "Jim", "Moriarity");
            _accountStore.CurrentAccount = accountModel;

            _navigationService.Navigate();
        }
        #endregion
    }
}
