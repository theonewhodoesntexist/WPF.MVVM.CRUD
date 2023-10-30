using CRUD.WPF.Commands;
using CRUD.WPF.Services;
using CRUD.WPF.Stores;
using CRUD.WPF.ViewModels.Account;
using CRUD.WPF.ViewModels.Dashboard;
using CRUD.WPF.ViewModels.Login;
using CRUD.WPF.ViewModels.Records;
using System.Runtime.CompilerServices;
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
        public bool IsLoggedIn => !_accountStore.IsLoggedIn;
        public bool IsLoggedOut => _accountStore.IsLoggedIn;
        #endregion

        #region Constructor
        public LayoutViewModel(
            INavigationService<DashboardViewModel> dashboardNavigationService,
            INavigationService<RecordsViewModel> recordsNavigationService,
            INavigationService<AccountViewModel> accountNavigationService,
            INavigationService<LoginViewModel> loginNavigationService,
            ViewModelBase contentViewModel,
            AccountStore accountStore)
        {
            NavigateDashboardCommand = new NavigateCommand<DashboardViewModel>(dashboardNavigationService);
            NavigateRecordsCommand = new NavigateCommand<RecordsViewModel>(recordsNavigationService);
            NavigateAccountCommand = new NavigateCommand<AccountViewModel>(accountNavigationService);
            LoginCommand = new NavigateCommand<LoginViewModel>(loginNavigationService);

            ContentViewModel = contentViewModel;
            _accountStore = accountStore;
        }
        #endregion
    }
}
