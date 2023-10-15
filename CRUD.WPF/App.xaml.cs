using CRUD.WPF.ViewModels.Account;
using CRUD.WPF.ViewModels.Dashboard;
using CRUD.WPF.ViewModels.Records;
using System.Windows;

namespace CRUD.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Startup configurations
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new DashboardViewModel() 
            };
            MainWindow.Show();
        }
        #endregion
    }
}
