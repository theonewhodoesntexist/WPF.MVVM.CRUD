using CRUD.WPF.Stores;
using CRUD.WPF.ViewModels.Account;
using CRUD.WPF.ViewModels.Dashboard;
using CRUD.WPF.ViewModels.Login;
using CRUD.WPF.ViewModels.Records;

namespace CRUD.WPF.Services
{
    public class NavigationManager
    {
        #region Fields
        private readonly NavigationStore _navigationStore;
        private readonly AccountStore _accountStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        #endregion

        #region Constructor
        public NavigationManager(
            NavigationStore navigationStore, 
            AccountStore accountStore, 
            ModalNavigationStore modalNavigationStore)
        {
            _navigationStore = navigationStore;
            _accountStore = accountStore;
            _modalNavigationStore = modalNavigationStore;
        }
        #endregion

        #region Helper methods
        public INavigationService DashboardNavigationService()
        {
            return new LayoutNavigationService<DashboardViewModel>(
                _navigationStore,
                () => new DashboardViewModel(_navigationStore, _accountStore),
                _accountStore,
                this);
        }

        public INavigationService RecordsNavigationService()
        {
            return new LayoutNavigationService<RecordsViewModel>(
                _navigationStore,
                () => new RecordsViewModel(
                    _navigationStore,
                    _accountStore, 
                    CreateRecordsNavigationService(), 
                    UpdateRecordsNavigationService()),
                _accountStore,
                this);
        }

        public INavigationService CreateRecordsNavigationService()
        {
            return new ModalNavigationService<CreateRecordsViewModel>(
                _modalNavigationStore, 
                () => new CreateRecordsViewModel(new CloseModalNavigationService(_modalNavigationStore)));
        }

        public INavigationService UpdateRecordsNavigationService()
        {
            return new ModalNavigationService<UpdateRecordsViewModel>(
                _modalNavigationStore,
                () => new UpdateRecordsViewModel(new CloseModalNavigationService(_modalNavigationStore)));
        }

        public INavigationService AccountNavigationService()
        {
            return new LayoutNavigationService<AccountViewModel>(
                _navigationStore,
                () => new AccountViewModel(_navigationStore, _accountStore),
                _accountStore,
                this);
        }

        public INavigationService LoginNavigationService()
        {
            return new NavigationService<LoginViewModel>(
                _navigationStore, 
                () => new LoginViewModel(
                    _navigationStore,
                    _accountStore, 
                    RecordsNavigationService()));
        }
        #endregion
    }
}
