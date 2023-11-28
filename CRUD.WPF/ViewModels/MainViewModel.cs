using CRUD.WPF.Stores;

namespace CRUD.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Fields
        private readonly NavigationStore _navigationStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        #endregion

        #region Properties
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        public ViewModelBase CurrentModalViewModel => _modalNavigationStore.CurrentModalViewModel;
        public bool IsModalOpen => _modalNavigationStore.IsOpen;
        #endregion

        #region Constructor
        public MainViewModel(NavigationStore navigationStore, ModalNavigationStore modalNavigationStore)
        {
            _navigationStore = navigationStore;
            _modalNavigationStore = modalNavigationStore;

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
    }
}
