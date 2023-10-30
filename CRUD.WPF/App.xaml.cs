using CRUD.WPF.Services;
using CRUD.WPF.Stores;
using CRUD.WPF.ViewModels;
using CRUD.WPF.ViewModels.Account;
using CRUD.WPF.ViewModels.Dashboard;
using CRUD.WPF.ViewModels.Login;
using CRUD.WPF.ViewModels.Records;
using System.Windows;

namespace CRUD.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Fields
        private readonly NavigationStore _navigationStore;
        private readonly AccountStore _accountStore;
        #endregion

        #region Constructor
        public App()
        {
            _navigationStore = new NavigationStore();
            _accountStore = new AccountStore();
        }
        #endregion

        #region Startup configurations
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            INavigationService<RecordsViewModel> recordsNavigationService = CreateRecordsNavigationService();
            recordsNavigationService.Navigate();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore) 
            };
            MainWindow.Show();
        }
        #endregion

        #region Helper methods
        private INavigationService<DashboardViewModel> CreateDashboardNavigationService()
        {
            return new LayoutNavigationService<DashboardViewModel>(
                _navigationStore,
                () => new DashboardViewModel(_navigationStore, _accountStore),
                _accountStore,
                CreateLoginNavigationService());
        }

        private INavigationService<RecordsViewModel> CreateRecordsNavigationService()
        {
            return new LayoutNavigationService<RecordsViewModel>(
                _navigationStore, 
                () => new RecordsViewModel(_navigationStore, _accountStore),
                _accountStore,
                CreateLoginNavigationService());
        }

        private INavigationService<AccountViewModel> CreateAccountNavigationService()
        {
            return new LayoutNavigationService<AccountViewModel>(
                _navigationStore, 
                () => new AccountViewModel(_navigationStore, _accountStore),
                _accountStore,
                CreateLoginNavigationService());
        }

        private INavigationService<LoginViewModel> CreateLoginNavigationService()
        {
            return new NavigationService<LoginViewModel>(
                _navigationStore,
                () => new LoginViewModel(_navigationStore, _accountStore, CreateRecordsNavigationService()));
        }
        #endregion
    }
}
