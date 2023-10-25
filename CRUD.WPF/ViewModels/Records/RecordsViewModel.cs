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
        #endregion

        #region Properties
        public RecordsListingViewModel RecordsListingViewModel { get; }
        public RecordsDetailsViewModel RecordsDetailsViewModel { get; }
        public ICommand NavigateDashboardCommand { get; }
        public ICommand NavigateAccountCommand { get; }
        #endregion

        #region Constructor
        public RecordsViewModel(NavigationStore navigationStore)
        {
            RecordsListingViewModel = new RecordsListingViewModel();
            RecordsDetailsViewModel = new RecordsDetailsViewModel();

            _navigationStore = navigationStore;
            NavigateDashboardCommand = new NavigateCommand<DashboardViewModel>(new NavigationService<DashboardViewModel>(_navigationStore, () => new DashboardViewModel(_navigationStore)));
            NavigateAccountCommand = new NavigateCommand<AccountViewModel>(new NavigationService<AccountViewModel>(_navigationStore, () => new AccountViewModel(_navigationStore)));
        }
        #endregion
    }
}
