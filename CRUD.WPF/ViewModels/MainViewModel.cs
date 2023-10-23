using CRUD.WPF.Stores;

namespace CRUD.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Fields
        private readonly NavigationStore _navigationStore;
        #endregion

        #region Properties
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        #endregion

        #region Constructor
        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            _navigationStore.CurrentViewModelChanged += NavigationStore_CurrentViewModelChanged;
        }

        #region CurrentViewModelChanged Subscribed
        private void NavigationStore_CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        #endregion
        #endregion
    }
}
