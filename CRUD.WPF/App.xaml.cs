using CRUD.WPF.Services;
using CRUD.WPF.Stores;
using CRUD.WPF.ViewModels;
using CRUD.WPF.ViewModels.Account;
using CRUD.WPF.ViewModels.Dashboard;
using CRUD.WPF.ViewModels.Login;
using CRUD.WPF.ViewModels.Records;
using System;
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
        private readonly ModalNavigationStore _modalNavigationStore;
        #endregion

        #region Constructor
        public App()
        {
            _navigationStore = new NavigationStore();
            _accountStore = new AccountStore();
            _modalNavigationStore = new ModalNavigationStore();
        }
        #endregion

        #region Startup configurations
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            INavigationService recordsNavigationService = CreateRecordsNavigationService();
            recordsNavigationService.Navigate();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore, _modalNavigationStore) 
            };
            MainWindow.Show();
        }
        #endregion

        #region Helper methods

        private INavigationService CreateRecordsNavigationService()
        {
            return new LayoutNavigationService<RecordsViewModel>(
                _navigationStore, 
                () => new RecordsViewModel(_navigationStore, _accountStore, CreateCreateRecordsNavigationService(), CreateUpdateRecordsNavigationService()),
                _accountStore,
                CreateLoginNavigationService(),
                _modalNavigationStore);
        }

        private INavigationService CreateLoginNavigationService()
        {
            return new NavigationService<LoginViewModel>(
                _navigationStore,
                () => new LoginViewModel(_navigationStore, _accountStore, CreateRecordsNavigationService()));
        }

        private INavigationService CreateCreateRecordsNavigationService()
        {
            return new ModalNavigationService<CreateRecordsViewModel>(_modalNavigationStore, () => new CreateRecordsViewModel(new CloseModalNavigationService(_modalNavigationStore)));
        }

        private INavigationService CreateUpdateRecordsNavigationService()
        {
            return new ModalNavigationService<UpdateRecordsViewModel>(_modalNavigationStore, () => new UpdateRecordsViewModel(new CloseModalNavigationService(_modalNavigationStore)));
        }
        #endregion
    }
}
