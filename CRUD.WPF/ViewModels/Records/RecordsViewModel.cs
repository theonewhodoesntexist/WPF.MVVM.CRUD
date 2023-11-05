using CRUD.WPF.Commands;
using CRUD.WPF.Services;
using CRUD.WPF.Stores;
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
        public ICommand CreateCommand { get; }
        public bool IsLoggedIn => _accountStore.IsLoggedIn;
        #endregion

        #region Constructor
        public RecordsViewModel(NavigationStore navigationStore, AccountStore accountStore, INavigationService createRecordsNavigationService, INavigationService updateRecordsNavigationService)
        {
            RecordsListingViewModel = new RecordsListingViewModel(updateRecordsNavigationService);
            RecordsDetailsViewModel = new RecordsDetailsViewModel();

            _navigationStore = navigationStore;
            _accountStore = accountStore;

            CreateCommand = new NavigateCommand(createRecordsNavigationService);
        }
        #endregion
    }
}
