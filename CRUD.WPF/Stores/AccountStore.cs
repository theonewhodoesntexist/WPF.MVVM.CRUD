using CRUD.WPF.Models;

namespace CRUD.WPF.Stores
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
            }
		}

		public bool IsLoggedIn => CurrentAccount != null;
        #endregion
    }
}
