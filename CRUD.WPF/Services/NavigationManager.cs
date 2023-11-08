using CRUD.WPF.Stores;
using CRUD.WPF.ViewModels;
using System;

namespace CRUD.WPF.Services
{
    public class NavigationManager
    {
        #region Fields
        private readonly NavigationStore _navigationStore;
        private readonly AccountStore _accountStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly SelectedStudentModelStore _selectedStudentModelStore;
        private readonly StudentModelStore _studentModelStore;
        #endregion

        #region Constructor
        public NavigationManager(
            NavigationStore navigationStore,
            AccountStore accountStore,
            ModalNavigationStore modalNavigationStore,
            SelectedStudentModelStore selectedStudentModelStore,
            StudentModelStore studentModelStore)
        {
            _navigationStore = navigationStore;
            _accountStore = accountStore;
            _modalNavigationStore = modalNavigationStore;
            _selectedStudentModelStore = selectedStudentModelStore;
            _studentModelStore = studentModelStore;
        }
        #endregion

        #region Helper methods
        public INavigationService CreateNavigationService<TViewModel>(Func<TViewModel> createViewModel)
            where TViewModel : ViewModelBase
        {
            return new NavigationService<TViewModel>(_navigationStore, createViewModel);
        }

        public INavigationService CreateLayoutNavigationService<TViewModel>(Func<TViewModel> createViewModel)
            where TViewModel : ViewModelBase
        {
            return new LayoutNavigationService<TViewModel>(
                _navigationStore,
                createViewModel,
                _accountStore,
                this,
                _selectedStudentModelStore,
                _studentModelStore);
        }

        public INavigationService CreateModalNavigationService<TViewModel>(Func<TViewModel> createViewModel)
            where TViewModel : ViewModelBase
        {
            return new ModalNavigationService<TViewModel>(
                _modalNavigationStore,
                createViewModel);
        }

        public INavigationService CreateCloseModalNavigationService()
        {
            return new CloseModalNavigationService(_modalNavigationStore);
        }
        #endregion
    }
}
