using CRUD.WPF.Stores;
using CRUD.WPF.ViewModels;
using System;

namespace CRUD.WPF.Services
{
    public class NavigationService<TViewModel> : INavigationService<TViewModel> 
        where TViewModel : ViewModelBase
    {
        #region Fields
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;
        #endregion

        #region Constructor
        public NavigationService(NavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }
        #endregion

        #region INavigationService
        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
        #endregion
    }
}
