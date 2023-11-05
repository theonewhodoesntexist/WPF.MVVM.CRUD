using CRUD.WPF.Stores;
using CRUD.WPF.ViewModels;
using System;

namespace CRUD.WPF.Services
{
    public class ModalNavigationService<TViewModel> : INavigationService
        where TViewModel : ViewModelBase
    {
        #region Fields
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly Func<TViewModel> _createViewModel;
        #endregion

        #region Constructor
        public ModalNavigationService(ModalNavigationStore modalNavigationStore, Func<TViewModel> createViewModel)
        {
            _modalNavigationStore = modalNavigationStore;
            _createViewModel = createViewModel;
        }
        #endregion

        #region INavigationService
        public void Navigate()
        {
            _modalNavigationStore.CurrentModalViewModel = _createViewModel();
        }
        #endregion
    }
}
