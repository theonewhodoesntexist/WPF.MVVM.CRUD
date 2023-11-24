using CRUD.WPF.Models;
using System;
using System.Threading.Tasks;

namespace CRUD.WPF.Stores.Accounts
{
    public class AccountModelStore
    {
        #region Events
        public event Action<AccountModel> AccountModelUpdated;
        #endregion

        #region Helper methods
        public async Task Update(AccountModel accountModel)
        {
            AccountModelUpdated?.Invoke(accountModel);
        }
        #endregion
    }
}
