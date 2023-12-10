using CRUD.WPF.Stores.Accounts;
using System;
using System.Threading.Tasks;

namespace CRUD.WPF.Commands.Accounts
{
    public class LoadAccountCommand : AsyncCommandBase
    {
        #region Fields
        private readonly AccountModelStore _accountModelStore;
        #endregion

        #region Constructor
        public LoadAccountCommand(AccountModelStore accountModelStore)
        {
            _accountModelStore = accountModelStore;
        }
        #endregion

        #region AsyncCommandBase
        public async override Task ExecuteAsync(object? parameter)
        {
            try
            {
                await _accountModelStore.Load();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
