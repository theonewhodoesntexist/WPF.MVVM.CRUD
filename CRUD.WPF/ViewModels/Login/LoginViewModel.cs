using CRUD.WPF.Commands;
using CRUD.WPF.Commands.Accounts;
using CRUD.WPF.Commands.Login;
using CRUD.WPF.Services;
using CRUD.WPF.Stores.Accounts;
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
        public ICommand LoadAccountCommand { get; }
        public ICommand CreateAccountCommand { get; }

        private bool _isLoading;
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);
        public ICommand ErrorCommand { get; }
        #endregion

        #region Constructor
        public LoginViewModel(
			AccountStore accountStore, 
			NavigationManager navigationManager,
            AccountModelStore accountModelStore)
        {
            LoadAccountCommand = new LoadAccountCommand(accountModelStore, this);
            CreateAccountCommand = new CreateAccountCommand(accountModelStore, this);
            LoginCommand = new LoginCommand(
                navigationManager.RecordsNavigationService(), 
				this,
                accountStore,
				accountModelStore);
			CancelCommand = new NavigateCommand(
                navigationManager.RecordsNavigationService());
            ErrorCommand = CancelCommand;
        }
        #endregion

        #region Helper methods
        public static LoginViewModel LoadViewModel(
            AccountStore accountStore,
            NavigationManager navigationManager,
            AccountModelStore accountModelStor)
        {
            LoginViewModel loginViewModel = new LoginViewModel(accountStore, navigationManager, accountModelStor);

            loginViewModel.LoadAccountCommand.Execute(null);
            loginViewModel.CreateAccountCommand.Execute(null);

            return loginViewModel;
        }
        #endregion
    }
}
