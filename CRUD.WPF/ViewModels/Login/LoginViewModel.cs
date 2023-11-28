using CRUD.WPF.Commands;
using CRUD.WPF.Commands.Login;
using CRUD.WPF.Services;
using CRUD.WPF.Stores.Accounts;
using System.Windows.Input;

namespace CRUD.WPF.ViewModels.Login
{
    public class LoginViewModel : ViewModelBase
    {
        #region Fields
        private readonly AccountStore _accountStore;
        private readonly NavigationManager _navigationManager;
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
			AccountStore accountStore, 
			NavigationManager navigationManager)
        {
            _accountStore = accountStore;
            _navigationManager = navigationManager;

            LoginCommand = new LoginCommand(
				_navigationManager.RecordsNavigationService(), 
				this, 
				_accountStore);
			CancelCommand = new NavigateCommand(
				_navigationManager.RecordsNavigationService());
        }
        #endregion
    }
}
