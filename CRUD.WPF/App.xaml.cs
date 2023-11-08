using CRUD.WPF.Services;
using CRUD.WPF.Stores;
using CRUD.WPF.ViewModels;
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
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly SelectedStudentModelStore _selectedStudentModelStore;
        private readonly StudentModelStore _studentModelStore;
        private readonly NavigationManager _navigationManager;
        #endregion

        #region Constructor
        public App()
        {
            _navigationStore = new NavigationStore();
            _accountStore = new AccountStore();
            _modalNavigationStore = new ModalNavigationStore();
            _studentModelStore = new StudentModelStore();
            _selectedStudentModelStore = new SelectedStudentModelStore(_studentModelStore);
            _navigationManager = new NavigationManager(
                _navigationStore,
                _accountStore, 
                _modalNavigationStore,
                _selectedStudentModelStore,
                _studentModelStore);
        }
        #endregion

        #region Startup configurations
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            INavigationService recordsNavigationService = _navigationManager.CreateLayoutNavigationService(
                () => new RecordsViewModel(
                    _accountStore, 
                    _selectedStudentModelStore, 
                    _studentModelStore, 
                    _navigationStore,
                    _navigationManager));
            recordsNavigationService.Navigate();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore, _modalNavigationStore) 
            };
            MainWindow.Show();
        }
        #endregion
    }
}
