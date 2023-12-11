using CRUD.Domain.Commands;
using CRUD.Domain.Models;
using CRUD.Domain.Queries;
using CRUD.EntityFramework;
using CRUD.EntityFramework.Commands.AccountModelCommands;
using CRUD.EntityFramework.Commands.StudentModelCommands;
using CRUD.EntityFramework.Queries;
using CRUD.WPF.Commands.Accounts;
using CRUD.WPF.Services;
using CRUD.WPF.Stores;
using CRUD.WPF.Stores.Accounts;
using CRUD.WPF.Stores.Records;
using CRUD.WPF.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows;
using System.Windows.Input;

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
        private readonly AccountModelStore _accountModelStore;

        private readonly ClassManagementSystemDbContextFactory _classManagementSystemDbContextFactory;

        private readonly IGetAllQuery<StudentModel> _getAllStudentModelQuery;
        private readonly ICreateCommand<StudentModel> _createStudentModelCommand;
        private readonly IUpdateCommand<StudentModel> _updateStudentModelCommand;
        private readonly IDeleteCommand<Guid> _deleteStudentModelCommand;

        private readonly IGetAllQuery<AccountModel> _getAllAccountModelQuery;
        private readonly ICreateCommand<AccountModel> _createAccountModelCommand;
        private readonly IUpdateCommand<AccountModel> _updateAccountModelCommand;
        #endregion

        #region Constructor
        public App()
        {
            string connectionString = "Data Source=ClassManagementSystem.db";
            _classManagementSystemDbContextFactory = new ClassManagementSystemDbContextFactory(
                new DbContextOptionsBuilder()
                .UseSqlite(connectionString)
                .Options);

            _getAllStudentModelQuery = new GetAllStudentModelQuery(_classManagementSystemDbContextFactory);
            _createStudentModelCommand = new CreateStudentModelCommand(_classManagementSystemDbContextFactory);
            _updateStudentModelCommand = new UpdateStudentModelCommand(_classManagementSystemDbContextFactory);
            _deleteStudentModelCommand = new DeleteStudentModelCommand(_classManagementSystemDbContextFactory);

            _getAllAccountModelQuery = new GetAllAccountModelQuery(_classManagementSystemDbContextFactory);
            _createAccountModelCommand = new CreateAccountModelCommand(_classManagementSystemDbContextFactory);
            _updateAccountModelCommand = new UpdateAccountModelCommand(_classManagementSystemDbContextFactory);

            _navigationStore = new NavigationStore();
            _accountStore = new AccountStore();
            _modalNavigationStore = new ModalNavigationStore();
            _studentModelStore = new StudentModelStore(
                _getAllStudentModelQuery,
                _createStudentModelCommand,
                _updateStudentModelCommand,
                _deleteStudentModelCommand);
            _selectedStudentModelStore = new SelectedStudentModelStore(_studentModelStore);
            _accountModelStore = new AccountModelStore(
                _getAllAccountModelQuery,
                _createAccountModelCommand,
                _updateAccountModelCommand);
            _navigationManager = new NavigationManager(
                _navigationStore,
                _accountStore,
                _modalNavigationStore,
                _selectedStudentModelStore,
                _studentModelStore,
                _accountModelStore);
        }
        #endregion

        #region Startup configurations
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            using (ClassManagementSystemDbContext context = _classManagementSystemDbContextFactory.Create())
            {
                context.Database.Migrate();
            }

            INavigationService recordsNavigationService = _navigationManager.RecordsNavigationService();
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
