﻿using CRUD.WPF.Stores;
using CRUD.WPF.Stores.Accounts;
using CRUD.WPF.Stores.Dashboard;
using CRUD.WPF.Stores.Records;
using CRUD.WPF.ViewModels;
using CRUD.WPF.ViewModels.Account;
using CRUD.WPF.ViewModels.Dashboard;
using CRUD.WPF.ViewModels.Login;
using CRUD.WPF.ViewModels.Records;
using System;

namespace CRUD.WPF.Services
{
    public class NavigationManager
    {
        #region Fields
        private readonly NavigationStore _navigationStore;
        private readonly AccountStore _accountStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly SelectedStudentModelStore _selectedStudentModelStore;
        private readonly StudentModelStore _studentModelStore;
        private readonly AccountModelStore _accountModelStore;
        private readonly DashboardStudentsStores _dashboardStudentsStores;
        #endregion

        #region Constructor
        public NavigationManager(
            NavigationStore navigationStore,
            AccountStore accountStore,
            ModalNavigationStore modalNavigationStore,
            SelectedStudentModelStore selectedStudentModelStore,
            StudentModelStore studentModelStore,
            AccountModelStore accountModelStore,
            DashboardStudentsStores dashboardStudentsStores)
        {
            _navigationStore = navigationStore;
            _accountStore = accountStore;
            _modalNavigationStore = modalNavigationStore;
            _selectedStudentModelStore = selectedStudentModelStore;
            _studentModelStore = studentModelStore;
            _accountModelStore = accountModelStore;
            _dashboardStudentsStores = dashboardStudentsStores;
        }
        #endregion

        #region Helper methods
        public INavigationService CreateNavigationService<TViewModel>(Func<TViewModel> createViewModel)
            where TViewModel : ViewModelBase
        {
            return new NavigationService<TViewModel>(_navigationStore, createViewModel);
        }

        public INavigationService CreateLayoutNavigationService<TViewModel>(Func<TViewModel> createViewModel)
            where TViewModel : ViewModelBase
        {
            return new LayoutNavigationService<TViewModel>(
                _navigationStore,
                createViewModel,
                _accountStore,
                this);
        }

        public INavigationService CreateModalNavigationService<TViewModel>(Func<TViewModel> createViewModel)
            where TViewModel : ViewModelBase
        {
            return new ModalNavigationService<TViewModel>(
                _modalNavigationStore,
                createViewModel);
        }

        public INavigationService CreateCloseModalNavigationService()
        {
            return new CloseModalNavigationService(_modalNavigationStore);
        }

        public INavigationService DashboardNavigationService()
        {
            return CreateLayoutNavigationService(() => new DashboardViewModel(_dashboardStudentsStores));
        }

        public INavigationService RecordsNavigationService()
        {
            return CreateLayoutNavigationService(
                () => new RecordsViewModel( 
                    _accountStore,
                    _selectedStudentModelStore, 
                    _studentModelStore,
                    this,
                    _dashboardStudentsStores));
        }

        public INavigationService AccountNavigationService()
        {
            return CreateLayoutNavigationService(
                () => new AccountViewModel(
                    _accountStore, 
                    this,
                    _accountModelStore));
        }

        public INavigationService LoginNavigationService()
        {
            return CreateNavigationService(
                () => new LoginViewModel(
                    _accountStore, 
                    this,
                    _selectedStudentModelStore,
                    _studentModelStore));
        }
        #endregion
    }
}
