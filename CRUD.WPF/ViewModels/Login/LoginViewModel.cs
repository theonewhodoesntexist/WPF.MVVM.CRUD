using CRUD.WPF.Commands;
using CRUD.WPF.Commands.Login;
using CRUD.WPF.Services;
using CRUD.WPF.Stores.Accounts;
using CRUD.WPF.ViewModels.Account;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CRUD.WPF.ViewModels.Login
{
    public class LoginViewModel : ViewModelBase
    {
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
			NavigationManager navigationManager,
            AccountModelStore accountModelStore)
        {
            LoginCommand = new LoginCommand(
                navigationManager.RecordsNavigationService(), 
				this,
                accountStore,
				accountModelStore);
			CancelCommand = new NavigateCommand(
                navigationManager.RecordsNavigationService());
        }
        #endregion
    }
}
