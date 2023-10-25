using CRUD.WPF.Commands;
using CRUD.WPF.Services;
using CRUD.WPF.Stores;
using CRUD.WPF.ViewModels.Account;
using CRUD.WPF.ViewModels.Dashboard;
using System.Windows.Input;

namespace CRUD.WPF.ViewModels.Records
{
    public class RecordsViewModel : ViewModelBase
    {
        #region Fields
        private readonly NavigationStore _navigationStore;
        private readonly AccountStore _accountStore;
        #endregion

        #region Properties
        public RecordsListingViewModel RecordsListingViewModel { get; }
        public RecordsDetailsViewModel RecordsDetailsViewModel { get; }
        public ICommand NavigateDashboardCommand { get; }
        public ICommand NavigateAccountCommand { get; }
        #endregion

        #region Constructor
        public RecordsViewModel(NavigationStore navigationStore, AccountStore accountStore)
        {
            RecordsListingViewModel = new RecordsListingViewModel();
            RecordsDetailsViewModel = new RecordsDetailsViewModel();

            _navigationStore = navigationStore;
            _accountStore = accountStore;
            NavigateDashboardCommand = new NavigateCommand<DashboardViewModel>(new NavigationService<DashboardViewModel>(_navigationStore, () => new DashboardViewModel(_navigationStore, _accountStore )));
            NavigateAccountCommand = new NavigateCommand<AccountViewModel>(new NavigationService<AccountViewModel>(_navigationStore, () => new AccountViewModel(_navigationStore, _accountStore)));
        }
        #endregion
    }
}
