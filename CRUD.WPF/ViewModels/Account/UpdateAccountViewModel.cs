using CRUD.WPF.Commands;
using CRUD.WPF.Commands.Accounts;
using CRUD.Domain.Models;
using CRUD.WPF.Services;
using CRUD.WPF.Stores.Accounts;
using System.Windows.Input;

namespace CRUD.WPF.ViewModels.Account
{
    public class UpdateAccountViewModel : ViewModelBase
    {
        #region Fields
        private readonly NavigationManager _navigationManager;
        private readonly AccountModelStore _accountModelStore;
        private readonly AccountViewModel _accountViewModel;
		#endregion

		#region Properties
		public AccountModel AccountModel => _accountViewModel.AccountModel;

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
				OnPropertyChanged(nameof(Username));
				OnPropertyChanged(nameof(CanUpdate));
			}
		}

		private string _firstName;
		public string FirstName
		{
			get
			{
                return _firstName;
            }
			set
			{
                _firstName = value;
				OnPropertyChanged(nameof(FirstName));
				OnPropertyChanged(nameof(CanUpdate));
			}
		}

		private string _lastName;
		public string LastName
		{
			get
			{
				return _lastName;
            }
			set
			{
                _lastName = value;
				OnPropertyChanged(nameof(LastName));
				OnPropertyChanged(nameof(CanUpdate));
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
				OnPropertyChanged(nameof(Password));
				OnPropertyChanged(nameof(CanUpdate));
			}
		}

        private bool _isSubmitting;
        public bool IsSubmitting
        {
            get
            {
                return _isSubmitting;
            }
            set
            {
                _isSubmitting = value;
                OnPropertyChanged(nameof(IsSubmitting));
            }
        }

        public bool CanUpdate => 
			(AccountModel.Username != Username ||
			AccountModel.FirstName != FirstName || 
			AccountModel.LastName != LastName ||
			AccountModel.Password != Password) &&
            !string.IsNullOrEmpty(Username) &&
            !string.IsNullOrEmpty(FirstName) &&
            !string.IsNullOrEmpty(LastName) &&
            !string.IsNullOrEmpty(Password);
        public ICommand UpdateCommand { get; }
        public ICommand CloseCommand { get; }

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
        public UpdateAccountViewModel(
			NavigationManager navigationManager,
			AccountModelStore accountModelStore,
			AccountViewModel accountViewModel)
        {
            _navigationManager = navigationManager;
            _accountModelStore = accountModelStore;
            _accountViewModel = accountViewModel;

            UpdateCommand = new UpdateAccountCommand(
				_accountModelStore,
				_navigationManager.CreateCloseModalNavigationService(),
				this);
            CloseCommand = new NavigateCommand(_navigationManager.CreateCloseModalNavigationService());
            ErrorCommand = CloseCommand;
        }
        #endregion
    }
}
