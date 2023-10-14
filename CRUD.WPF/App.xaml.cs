using CRUD.WPF.ViewModels;
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
                DataContext = new RecordsViewModel() 
            };
            MainWindow.Show();
        }
        #endregion
    }
}
