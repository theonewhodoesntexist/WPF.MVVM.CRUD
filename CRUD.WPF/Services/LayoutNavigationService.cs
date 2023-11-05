using CRUD.WPF.Stores;
using CRUD.WPF.ViewModels;
using CRUD.WPF.ViewModels.Account;
using CRUD.WPF.ViewModels.Dashboard;
using CRUD.WPF.ViewModels.Layout;
using CRUD.WPF.ViewModels.Records;
using System;

namespace CRUD.WPF.Services
{
    public class LayoutNavigationService<TViewModel> : INavigationService
        where TViewModel : ViewModelBase
    {
        #region Fields
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;
        private readonly AccountStore _accountStore;
        private readonly INavigationService _loginNavigationService;
        private readonly ModalNavigationStore _modalNavigationStore;
        #endregion

        #region Constructor
        public LayoutNavigationService(
            NavigationStore navigationStore, 
            Func<TViewModel> createViewModel,
            AccountStore accountStore,
            INavigationService loginNavigationService,
            ModalNavigationStore modalNavigationStore)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
            _accountStore = accountStore;
            _loginNavigationService = loginNavigationService;
            _modalNavigationStore = modalNavigationStore;
        }
        #endregion

        #region INavigationService
        public void Navigate()
        {
            INavigationService dashboardNavigationService = CreateLayoutNavigationService(
                    _navigationStore,
                    () => new DashboardViewModel(_navigationStore, _accountStore),
                    _accountStore,
                    _loginNavigationService,
                    _modalNavigationStore);

            INavigationService recordsNavigationService = CreateLayoutNavigationService(
                    _navigationStore,
                    () => new RecordsViewModel(
                        _navigationStore,
                        _accountStore,
                        CreateModalNavigationService(_modalNavigationStore, () => new CreateRecordsViewModel(CreateCloseModalNavigationService(_modalNavigationStore))),
                        CreateModalNavigationService(_modalNavigationStore, () => new UpdateRecordsViewModel(CreateCloseModalNavigationService(_modalNavigationStore)))),
                    _accountStore,
                    _loginNavigationService,
                    _modalNavigationStore);

            INavigationService accountNavigationService = CreateLayoutNavigationService(
                    _navigationStore,
                    () => new AccountViewModel(_navigationStore, _accountStore),
                    _accountStore,
                    _loginNavigationService,
                    _modalNavigationStore);

            _navigationStore.CurrentViewModel = new LayoutViewModel(
                dashboardNavigationService,
                recordsNavigationService,
                accountNavigationService,
                _loginNavigationService,
                _createViewModel(),
                _accountStore);
        }
        #endregion

        #region Helper methods
        public INavigationService CreateLayoutNavigationService<TNewViewModel>(
            NavigationStore navigationStore, 
            Func<TNewViewModel> createViewModel, 
            AccountStore accountStore, 
            INavigationService loginNavigationService,
            ModalNavigationStore modalNavigationStore)
            where TNewViewModel : ViewModelBase
        {
            return new LayoutNavigationService<TNewViewModel>(navigationStore, createViewModel, accountStore, loginNavigationService, modalNavigationStore);
        }

        public INavigationService CreateModalNavigationService<TNewViewModel>(ModalNavigationStore modalNavigationStore, Func<TNewViewModel> createViewModel)
            where TNewViewModel : ViewModelBase
        {
            return new ModalNavigationService<TNewViewModel>(modalNavigationStore, createViewModel);
        }

        public INavigationService CreateCloseModalNavigationService(ModalNavigationStore modalNavigationStore)
        {
            return new CloseModalNavigationService(modalNavigationStore);
        }
        #endregion
    }
}
