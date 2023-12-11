using CRUD.WPF.Commands;
using CRUD.WPF.Commands.Records;
using CRUD.WPF.Services;
using CRUD.WPF.Stores.Accounts;
using CRUD.WPF.Stores.Records;
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
        public ICommand LoadRecordsCommand { get; }

        private bool _isLoading;
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }
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

            RecordsListingViewModel = new RecordsListingViewModel(
                _selectedStudentModelStore, 
                _studentModelStore, 
                _navigationManager,
                _accountStore);
            RecordsDetailsViewModel = new RecordsDetailsViewModel(_selectedStudentModelStore);
            CreateCommand = new NavigateCommand(
                _navigationManager.CreateModalNavigationService(
                    () => new CreateRecordsViewModel(
                        _studentModelStore,
                        _navigationManager)));

            LoadRecordsCommand = new LoadRecordsCommand(_studentModelStore, this);

            _accountStore.CurrentAccountChanged += AccountStore_CurrentAccountChanged;
        }
        #endregion

        #region Subscribers
        private void AccountStore_CurrentAccountChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
        }
        #endregion

        #region Dispose
        public override void Dispose()
        {
            RecordsListingViewModel.Dispose();
            RecordsDetailsViewModel.Dispose();
            _accountStore.CurrentAccountChanged -= AccountStore_CurrentAccountChanged;

            base.Dispose();
        }
        #endregion

        #region Helper methods
        public static RecordsViewModel LoadViewModel(
            AccountStore accountStore,
            SelectedStudentModelStore selectedStudentModelStore,
            StudentModelStore studentModelStore,
            NavigationManager navigationManager)
        {
            RecordsViewModel recordsViewModel = new RecordsViewModel(
                accountStore, 
                selectedStudentModelStore,
                studentModelStore, 
                navigationManager);

            recordsViewModel.LoadRecordsCommand.Execute(null);

            return recordsViewModel;
        }
        #endregion
    }
}
