using CRUD.WPF.Stores;
using CRUD.WPF.ViewModels.Layout;
using System.Windows.Input;

namespace CRUD.WPF.ViewModels.Account
{
    public class AccountViewModel : ViewModelBase
    {
        #region Fields
        private readonly NavigationStore _navigationStore;
        private readonly AccountStore _accountStore;
        #endregion

        #region Properties
        public string Username => _accountStore.CurrentAccount?.Username ?? "None";
        public string FullName => $"{FirstName} {LastName}";
        public string FirstName => _accountStore.CurrentAccount?.FirstName ?? "None";
        public string LastName => _accountStore.CurrentAccount?.LastName ?? string.Empty;
        public ICommand EditAccountCommand { get; }
        #endregion

        #region Constructor
        public AccountViewModel(NavigationStore navigationStore, AccountStore accountStore)
        {
            _navigationStore = navigationStore;
            _accountStore = accountStore;
        }
        #endregion
    }
}
