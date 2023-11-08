using CRUD.WPF.Commands;
using CRUD.WPF.Commands.Login;
using CRUD.WPF.Services;
using CRUD.WPF.Stores;
using CRUD.WPF.ViewModels.Records;
using System.Windows.Input;

namespace CRUD.WPF.ViewModels.Login
{
    public class LoginViewModel : ViewModelBase
    {
        #region Fields
        private readonly NavigationStore _navigationStore;
        private readonly AccountStore _accountStore;
        private readonly NavigationManager _navigationManager;
        private readonly SelectedStudentModelStore _selectedStudentModelStore;
        private readonly StudentModelStore _studentModelStore;
        #endregion

        #region Properties
        private string _username;
		public string Username
		{
			get
			{
				return _username;
			}
			set
			{
				_username = value;
			}
		}

		private string _password;
        public string Password
		{
			get
			{
				return _password;
			}
			set
			{
				_password = value;
			}
		}
		
		public ICommand LoginCommand { get; }
		public ICommand CancelCommand { get; }
        #endregion

        #region Constructor
        public LoginViewModel(
			NavigationStore navigationStore, 
			AccountStore accountStore, 
			NavigationManager navigationManager, 
			SelectedStudentModelStore selectedStudentModelStore, 
			StudentModelStore studentModelStore)
        {
            _navigationStore = navigationStore;
            _accountStore = accountStore;
            _navigationManager = navigationManager;
            _selectedStudentModelStore = selectedStudentModelStore;
            _studentModelStore = studentModelStore;
            LoginCommand = new LoginCommand(_navigationManager.CreateLayoutNavigationService(() => new RecordsViewModel(_accountStore, _selectedStudentModelStore, _studentModelStore, _navigationStore, _navigationManager)), this, _accountStore);
			CancelCommand = new NavigateCommand(_navigationManager.CreateLayoutNavigationService(() => new RecordsViewModel(_accountStore, _selectedStudentModelStore, _studentModelStore, _navigationStore, _navigationManager)));
        }
        #endregion
    }
}
