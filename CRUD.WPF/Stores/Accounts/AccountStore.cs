using CRUD.Domain.Models;
using System;

namespace CRUD.WPF.Stores.Accounts
{
    public class AccountStore
    {
        #region Properties
        private AccountModel _currentAccount;
        public AccountModel CurrentAccount
        {
            get
            {
                return _currentAccount;
            }
            set
            {
                _currentAccount = value;
                CurrentAccountChanged?.Invoke();
            }
        }

        public bool IsLoggedIn => CurrentAccount != null;
        #endregion

        #region Events
        public event Action CurrentAccountChanged;
        #endregion

        #region Helper methods
        public void Logout()
        {
            CurrentAccount = null;
        }
        #endregion
    }
}
