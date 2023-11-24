using CRUD.WPF.Stores;
using CRUD.WPF.Stores.Accounts;
using CRUD.WPF.ViewModels;
using CRUD.WPF.ViewModels.Layout;
using System;

namespace CRUD.WPF.Services
{
    public class LayoutNavigationService<TViewModel> : INavigationService
        where TViewModel : ViewModelBase
    {
        #region Fields
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;
        private readonly AccountStore _accountStore;
        private readonly NavigationManager _navigationManager;
        #endregion

        #region Constructor
        public LayoutNavigationService(
            NavigationStore navigationStore, 
            Func<TViewModel> createViewModel,
            AccountStore accountStore,
            NavigationManager navigationManager)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
            _accountStore = accountStore;
            _navigationManager = navigationManager;
        }
        #endregion

        #region INavigationService
        public void Navigate()
        {
            _navigationStore.CurrentViewModel = new LayoutViewModel(
                _navigationManager,
                _createViewModel(),
                _accountStore);
        }
        #endregion
    }
}
