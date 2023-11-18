using CRUD.WPF.Commands;
using CRUD.WPF.Services;
using CRUD.WPF.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CRUD.WPF.ViewModels.Records
{
    public class RecordsViewModel : ViewModelBase
    {
        #region Fields
        private readonly AccountStore _accountStore;
        private readonly SelectedStudentModelStore _selectedStudentModelStore;
        private readonly StudentModelStore _studentModelStore;
        private readonly NavigationManager _navigationManager;
        #endregion

        #region Properties
        public RecordsListingViewModel RecordsListingViewModel { get; }
        public RecordsDetailsViewModel RecordsDetailsViewModel { get; }
        public ICommand CreateCommand { get; }
        public bool IsLoggedIn => _accountStore.IsLoggedIn;
        #endregion

        #region Constructor
        public RecordsViewModel(
            AccountStore accountStore, 
            SelectedStudentModelStore selectedStudentModelStore,
            StudentModelStore studentModelStore,
            NavigationManager navigationManager)
        {
            _accountStore = accountStore;
            _selectedStudentModelStore = selectedStudentModelStore;
            _studentModelStore = studentModelStore;
            _navigationManager = navigationManager;

            RecordsListingViewModel = new RecordsListingViewModel(_selectedStudentModelStore, _studentModelStore, _navigationManager);
            RecordsDetailsViewModel = new RecordsDetailsViewModel(_selectedStudentModelStore);
            CreateCommand = new NavigateCommand(
                _navigationManager.CreateModalNavigationService(
                    () => new CreateRecordsViewModel(
                        _studentModelStore,
                        _navigationManager)));
        }
        #endregion
    }
}
