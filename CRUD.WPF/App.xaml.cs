using CRUD.Domain.Commands;
using CRUD.Domain.Models;
using CRUD.Domain.Queries;
using CRUD.EntityFramework;
using CRUD.EntityFramework.Commands.AccountModelCommands;
using CRUD.EntityFramework.Commands.StudentModelCommands;
using CRUD.EntityFramework.Queries;
using CRUD.WPF.HostBuilders;
using CRUD.WPF.Services;
using CRUD.WPF.Stores;
using CRUD.WPF.Stores.Accounts;
using CRUD.WPF.Stores.Records;
using CRUD.WPF.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Windows;

namespace CRUD.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Fields
        private readonly IHost _host;
        #endregion

        #region Constructor
        public App()
        {
            _host = Host
                .CreateDefaultBuilder()
                .AddDbContext()
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<IGetAllQuery<StudentModel>, GetAllStudentModelQuery >();
                    services.AddSingleton<ICreateCommand<StudentModel>, CreateStudentModelCommand>();
                    services.AddSingleton<IUpdateCommand<StudentModel>, UpdateStudentModelCommand >();
                    services.AddSingleton<IDeleteCommand<Guid>, DeleteStudentModelCommand >();

                    services.AddSingleton<IGetAllQuery<AccountModel>, GetAllAccountModelQuery >();
                    services.AddSingleton<ICreateCommand<AccountModel>, CreateAccountModelCommand >();
                    services.AddSingleton<IUpdateCommand<AccountModel>, UpdateAccountModelCommand >();

                    services.AddSingleton<NavigationStore>();
                    services.AddSingleton<AccountStore>();
                    services.AddSingleton<ModalNavigationStore>();
                    services.AddSingleton<StudentModelStore>();
                    services.AddSingleton<SelectedStudentModelStore>();
                    services.AddSingleton<AccountModelStore>();
                    services.AddSingleton<NavigationManager>();

                    services.AddSingleton<MainViewModel>();

                    services.AddSingleton<MainWindow>((services) => new MainWindow()
                    {
                        DataContext = services.GetRequiredService<MainViewModel>()
                    });
                })
                .Build();
        }
        #endregion

        #region Startup configurations
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            _host.Start();

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string programFolder = Path.Combine(appDataPath, "Class Management System");
            AppDomain.CurrentDomain.SetData("DataDirectory", programFolder);
            if (!Directory.Exists(programFolder))
            {
                Directory.CreateDirectory(programFolder);
            }

            ClassManagementSystemDbContextFactory classManagementSystemDbContextFactory = _host.Services.GetRequiredService<ClassManagementSystemDbContextFactory>();
            using (ClassManagementSystemDbContext context = classManagementSystemDbContextFactory.Create())
            {
                context.Database.Migrate();
            }

            NavigationManager navigationManager = _host.Services.GetRequiredService<NavigationManager>();
            INavigationService recordsNavigationService = navigationManager.RecordsNavigationService();
            recordsNavigationService.Navigate();

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();
        }
        #endregion

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            _host.StopAsync();
            _host.Dispose();
        }
    }
}
