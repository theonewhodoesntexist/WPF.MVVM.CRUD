using CRUD.WPF.Commands;
using CRUD.WPF.Commands.Login;
using CRUD.WPF.Services;
using CRUD.WPF.Stores;
using System.Windows.Input;

namespace CRUD.WPF.ViewModels.Layout
{
    public class LayoutViewModel : ViewModelBase
    {
        #region Fields
        private readonly AccountStore _accountStore;
        #endregion
        #region Properties
        public ICommand NavigateDashboardCommand { get; }
        public ICommand NavigateRecordsCommand { get; }
        public ICommand NavigateAccountCommand { get; }
        public ICommand LoginCommand { get; }
        public ICommand LogoutCommand { get; }
        public ViewModelBase ContentViewModel { get; }
        public bool ToLogin => !_accountStore.IsLoggedIn;
        public bool ToLogout => _accountStore.IsLoggedIn;
        #endregion

        #region Constructor
        public LayoutViewModel(
            INavigationService dashboardNavigationService,
            INavigationService recordsNavigationService,
            INavigationService accountNavigationService,
            INavigationService loginNavigationService,
            ViewModelBase contentViewModel,
            AccountStore accountStore)
        {
            ContentViewModel = contentViewModel;
            _accountStore = accountStore;

            NavigateDashboardCommand = new NavigateCommand(dashboardNavigationService);
            NavigateRecordsCommand = new NavigateCommand(recordsNavigationService);
            NavigateAccountCommand = new NavigateCommand(accountNavigationService);
            LoginCommand = new NavigateCommand(loginNavigationService);
            LogoutCommand = new LogoutCommand(_accountStore, recordsNavigationService);

            _accountStore.CurrentAccountChanged += AccountStore_CurrentAccountChanged;
        }
        #endregion

        #region Subscribers
        private void AccountStore_CurrentAccountChanged()
        {
            OnPropertyChanged(nameof(ToLogin));
            OnPropertyChanged(nameof(ToLogout));
        }
        #endregion

        #region Dispose
        public override void Dispose()
        {
            ContentViewModel.Dispose();
            _accountStore.CurrentAccountChanged -= AccountStore_CurrentAccountChanged;

            base.Dispose();
        }
        #endregion
    }
}
