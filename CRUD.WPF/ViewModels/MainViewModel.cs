using CRUD.WPF.Commands.Accounts;
using CRUD.WPF.Stores;
using CRUD.WPF.Stores.Accounts;
using System.Windows.Input;

namespace CRUD.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Fields
        private readonly NavigationStore _navigationStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly AccountModelStore _accountModelStore;
        #endregion

        #region Properties
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        public ViewModelBase CurrentModalViewModel => _modalNavigationStore.CurrentModalViewModel;
        public bool IsModalOpen => _modalNavigationStore.IsOpen;
        public ICommand LoadAccountCommand { get; }

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
        public MainViewModel(
            NavigationStore navigationStore,
            ModalNavigationStore modalNavigationStore,
            AccountModelStore accountModelStore)
        {
            _navigationStore = navigationStore;
            _modalNavigationStore = modalNavigationStore;
            _accountModelStore = accountModelStore;

            LoadAccountCommand = new LoadAccountCommand(_accountModelStore, this);

            _navigationStore.CurrentViewModelChanged += NavigationStore_CurrentViewModelChanged;
            _modalNavigationStore.CurrentModalViewModelChanged += ModalNavigationStore_CurrentModalViewModelChanged;
        }
        #endregion

        #region Subscribers
        private void NavigationStore_CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private void ModalNavigationStore_CurrentModalViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentModalViewModel));
            OnPropertyChanged(nameof(IsModalOpen));
        }
        #endregion

        #region Dispose
        public override void Dispose()
        {
            CurrentViewModel.Dispose();
            CurrentModalViewModel.Dispose();
            _navigationStore.CurrentViewModelChanged -= NavigationStore_CurrentViewModelChanged;
            _modalNavigationStore.CurrentModalViewModelChanged -= ModalNavigationStore_CurrentModalViewModelChanged;

            base.Dispose();
        }
        #endregion

        #region Helper methods
        public static MainViewModel LoadViewModel(
            NavigationStore navigationStore,
            ModalNavigationStore modalNavigationStore,
            AccountModelStore accountModelStore)
        {
            MainViewModel mainViewModel = new MainViewModel(navigationStore, modalNavigationStore, accountModelStore);

            mainViewModel.LoadAccountCommand.Execute(null);

            return mainViewModel;
        }
        #endregion
    }
}
