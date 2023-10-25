using CRUD.WPF.Commands;
using CRUD.WPF.Services;
using CRUD.WPF.Stores;
using CRUD.WPF.ViewModels.Dashboard;
using CRUD.WPF.ViewModels.Records;
using System.Windows.Input;

namespace CRUD.WPF.ViewModels.Account
{
    public class AccountViewModel : ViewModelBase
    {
        #region Fields
        private readonly NavigationStore _navigationStore;
        private readonly AccountStore _accountStore;
        #endregion

        #region Properties
        public string Username => _accountStore.CurrentAccount?.Username ?? "None";
        public string FullName => $"{FirstName} {LastName}";
        public string FirstName => _accountStore.CurrentAccount?.FirstName ?? "None";
        public string LastName => _accountStore.CurrentAccount?.LastName ?? string.Empty;
        public ICommand EditAccountCommand { get; }
        public ICommand NavigateDashboardCommand { get; }
        public ICommand NavigateRecordsCommand { get; }
        #endregion

        #region Constructor
        public AccountViewModel(NavigationStore navigationStore, AccountStore accountStore)
        {
            _navigationStore = navigationStore;
            _accountStore = accountStore;
            NavigateDashboardCommand = new NavigateCommand<DashboardViewModel>(new NavigationService<DashboardViewModel>(_navigationStore, () => new DashboardViewModel(_navigationStore, _accountStore)));
            NavigateRecordsCommand = new NavigateCommand<RecordsViewModel>(new NavigationService<RecordsViewModel>(_navigationStore, () => new RecordsViewModel(_navigationStore, _accountStore)));
        }
        #endregion
    }
}
