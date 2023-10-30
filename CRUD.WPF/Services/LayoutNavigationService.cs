using CRUD.WPF.Stores;
using CRUD.WPF.ViewModels;
using CRUD.WPF.ViewModels.Account;
using CRUD.WPF.ViewModels.Dashboard;
using CRUD.WPF.ViewModels.Layout;
using CRUD.WPF.ViewModels.Login;
using CRUD.WPF.ViewModels.Records;
using System;

namespace CRUD.WPF.Services
{
    public class LayoutNavigationService<TViewModel> : INavigationService<TViewModel>
        where TViewModel : ViewModelBase
    {
        #region Fields
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;
        private readonly AccountStore _accountStore;
        private readonly INavigationService<LoginViewModel> _loginNavigationService;
        #endregion

        #region Constructor
        public LayoutNavigationService(
            NavigationStore navigationStore, 
            Func<TViewModel> createViewModel,
            AccountStore accountStore,
            INavigationService<LoginViewModel> loginNavigationService)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
            _accountStore = accountStore;
            _loginNavigationService = loginNavigationService;
        }
        #endregion

        #region INavigationService
        public void Navigate()
        {
            _navigationStore.CurrentViewModel = new LayoutViewModel(
                CreateLayoutNavigationService<DashboardViewModel>(_navigationStore, () => new DashboardViewModel(_navigationStore, _accountStore), _accountStore, _loginNavigationService),
                CreateLayoutNavigationService<RecordsViewModel>(_navigationStore, () => new RecordsViewModel(_navigationStore, _accountStore), _accountStore, _loginNavigationService),
                CreateLayoutNavigationService<AccountViewModel>(_navigationStore, () => new AccountViewModel(_navigationStore, _accountStore), _accountStore, _loginNavigationService),
                _loginNavigationService,
                _createViewModel(),
                _accountStore);
        }
        #endregion

        #region Helper methods
        public INavigationService<TNewViewModel> CreateLayoutNavigationService<TNewViewModel>(NavigationStore navigationStore, Func<TNewViewModel> createViewModel, AccountStore accountStore, INavigationService<LoginViewModel> loginNavigationService)
            where TNewViewModel : ViewModelBase
        {
            return new LayoutNavigationService<TNewViewModel>(navigationStore, createViewModel, accountStore, loginNavigationService);
        }
        #endregion
    }
}
