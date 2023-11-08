using CRUD.WPF.Commands;
using CRUD.WPF.Commands.Login;
using CRUD.WPF.Services;
using CRUD.WPF.Stores;
using CRUD.WPF.ViewModels.Account;
using CRUD.WPF.ViewModels.Dashboard;
using CRUD.WPF.ViewModels.Login;
using CRUD.WPF.ViewModels.Records;
using System.Windows.Input;

namespace CRUD.WPF.ViewModels.Layout
{
    public class LayoutViewModel : ViewModelBase
    {
        #region Fields
        private readonly NavigationManager _navigationManager;
        private readonly AccountStore _accountStore;
        private readonly NavigationStore _navigationStore;
        private readonly SelectedStudentModelStore _selectedStudentModelStore;
        private readonly StudentModelStore _studentModelStore;
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
            NavigationManager navigationManager,
            ViewModelBase contentViewModel,
            AccountStore accountStore,
            NavigationStore navigationStore,
            SelectedStudentModelStore selectedStudentModelStore,
            StudentModelStore studentModelStore)
        {
            _navigationManager = navigationManager;
            ContentViewModel = contentViewModel;
            _accountStore = accountStore;
            _navigationStore = navigationStore;
            _selectedStudentModelStore = selectedStudentModelStore;
            _studentModelStore = studentModelStore;

            NavigateDashboardCommand = new NavigateCommand(_navigationManager.CreateLayoutNavigationService(
                () => new DashboardViewModel(
                    _navigationStore,
                    _accountStore)));
            NavigateRecordsCommand = new NavigateCommand(_navigationManager.CreateLayoutNavigationService(
                () => new RecordsViewModel(
                    _accountStore, 
                    _selectedStudentModelStore,
                    _studentModelStore,
                    _navigationStore, 
                    _navigationManager)));
            NavigateAccountCommand = new NavigateCommand(_navigationManager.CreateLayoutNavigationService(
                () => new AccountViewModel(
                    _navigationStore, 
                    _accountStore)));
            LoginCommand = new NavigateCommand(_navigationManager.CreateNavigationService(
                () => new LoginViewModel(
                    _navigationStore,
                    _accountStore,
                    _navigationManager,
                    _selectedStudentModelStore,
                    _studentModelStore)));
            LogoutCommand = new LogoutCommand(
                _accountStore, 
                _navigationManager.CreateLayoutNavigationService(
                    () => new RecordsViewModel(
                        _accountStore, 
                        _selectedStudentModelStore,
                        _studentModelStore, 
                        _navigationStore,
                        _navigationManager)));

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
