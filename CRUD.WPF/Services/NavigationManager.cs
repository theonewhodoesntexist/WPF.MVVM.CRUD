﻿using CRUD.WPF.Stores;
using CRUD.WPF.ViewModels;
using CRUD.WPF.ViewModels.Account;
using CRUD.WPF.ViewModels.Dashboard;
using CRUD.WPF.ViewModels.Login;
using CRUD.WPF.ViewModels.Records;
using System;
using System.Collections.ObjectModel;

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
        #endregion

        #region Constructor
        public NavigationManager(
            NavigationStore navigationStore,
            AccountStore accountStore,
            ModalNavigationStore modalNavigationStore,
            SelectedStudentModelStore selectedStudentModelStore,
            StudentModelStore studentModelStore,
            AccountModelStore accountModelStore)
        {
            _navigationStore = navigationStore;
            _accountStore = accountStore;
            _modalNavigationStore = modalNavigationStore;
            _selectedStudentModelStore = selectedStudentModelStore;
            _studentModelStore = studentModelStore;
            _accountModelStore = accountModelStore;
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
            return CreateLayoutNavigationService(() => new DashboardViewModel());
        }

        public INavigationService RecordsNavigationService()
        {
            return CreateLayoutNavigationService(
                () => new RecordsViewModel( 
                    _accountStore,
                    _selectedStudentModelStore, 
                    _studentModelStore,
                    this));
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
