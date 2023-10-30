using CRUD.WPF.Stores;
using CRUD.WPF.ViewModels.Layout;
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
        public RecordsViewModel(NavigationStore navigationStore, AccountStore accountStore)
        {
            RecordsListingViewModel = new RecordsListingViewModel();
            RecordsDetailsViewModel = new RecordsDetailsViewModel();

            _navigationStore = navigationStore;
            _accountStore = accountStore;
        }
        #endregion
    }
}
