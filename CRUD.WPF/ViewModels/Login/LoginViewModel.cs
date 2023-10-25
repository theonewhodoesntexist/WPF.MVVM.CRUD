using CRUD.WPF.Commands.Login;
using CRUD.WPF.Services;
using CRUD.WPF.Stores;
using CRUD.WPF.ViewModels.Dashboard;
using System.Windows.Input;

namespace CRUD.WPF.ViewModels.Login
{
    public class LoginViewModel : ViewModelBase
    {
        #region Fields
        private readonly NavigationStore _navigationStore;
        private readonly AccountStore _accountStore;
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
        #endregion

        #region Constructor
        public LoginViewModel(NavigationStore navigationStore, AccountStore accountStore)
        {
            _navigationStore = navigationStore;
            _accountStore = accountStore;
            LoginCommand = new LoginCommand(new NavigationService<DashboardViewModel>(_navigationStore, () => new DashboardViewModel(_navigationStore, _accountStore)), this, _accountStore);
        }
        #endregion
    }
}
