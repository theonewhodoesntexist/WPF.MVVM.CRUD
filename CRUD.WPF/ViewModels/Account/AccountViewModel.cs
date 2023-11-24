using CRUD.WPF.Commands;
using CRUD.WPF.Models;
using CRUD.WPF.Services;
using CRUD.WPF.Stores.Accounts;
using System.Windows.Input;

namespace CRUD.WPF.ViewModels.Account
{
    public class AccountViewModel : ViewModelBase
    {
        #region Fields
        private readonly AccountStore _accountStore;
        private readonly NavigationManager _navigationManager;
        private readonly AccountModelStore _accountModelStore;
        #endregion

        #region Properties
        public AccountModel AccountModel => _accountStore.CurrentAccount;
        public string Username => AccountModel?.Username ?? "None";
        public string FullName => $"{FirstName} {LastName}";
        public string FirstName => AccountModel?.FirstName ?? "None";
        public string LastName => AccountModel?.LastName ?? string.Empty;
        public ICommand UpdateAccountCommand { get; }
        #endregion

        #region Constructor
        public AccountViewModel(AccountStore accountStore, NavigationManager navigationManager, AccountModelStore accountModelStore)
        {
            _accountStore = accountStore;
            _navigationManager = navigationManager;
            _accountModelStore = accountModelStore;

            UpdateAccountCommand = new NavigateCommand(
                _navigationManager.CreateModalNavigationService(
                    () => new UpdateAccountViewModel(
                        _navigationManager,
                        _accountModelStore,
                        this)
                    {
                        Username = AccountModel.Username,
                        FirstName = AccountModel.FirstName,
                        LastName = AccountModel.LastName,
                        Password = AccountModel.Password
                    }));

            _accountStore.CurrentAccountChanged += AccountStore_CurrentAccountChanged;
            _accountModelStore.AccountModelUpdated += AccountModelStore_AccountModelUpdated;
        }
        #endregion

        #region Subscribers
        private void AccountStore_CurrentAccountChanged()
        {
            OnPropertyChanged(nameof(Username));
            OnPropertyChanged(nameof(FullName));
            OnPropertyChanged(nameof(FirstName));
            OnPropertyChanged(nameof(LastName));
        }

        private void AccountModelStore_AccountModelUpdated(AccountModel accountModel)
        {
            _accountStore.CurrentAccount = accountModel;
        }
        #endregion

        #region Dispose
        public override void Dispose()
        {
            _accountStore.CurrentAccountChanged -= AccountStore_CurrentAccountChanged;
            _accountModelStore.AccountModelUpdated -= AccountModelStore_AccountModelUpdated;

            base.Dispose();
        }
        #endregion
    }
}
