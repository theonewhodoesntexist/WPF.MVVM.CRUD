using CRUD.WPF.Stores.Accounts;
using CRUD.WPF.ViewModels;
using System;
using System.Threading.Tasks;

namespace CRUD.WPF.Commands.Accounts
{
    public class LoadAccountCommand : AsyncCommandBase
    {
        #region Fields
        private readonly AccountModelStore _accountModelStore;
        private readonly MainViewModel _mainViewModel;
        #endregion

        #region Constructor
        public LoadAccountCommand(AccountModelStore accountModelStore, MainViewModel mainViewModel)
        {
            _accountModelStore = accountModelStore;
            _mainViewModel = mainViewModel;
        }
        #endregion

        #region AsyncCommandBase
        public async override Task ExecuteAsync(object? parameter)
        {
            _mainViewModel.IsLoading = true;

            try
            {
                await _accountModelStore.Load();
            }
            catch (Exception)
            {
                throw;
            }
            finally 
            { 
                _mainViewModel.IsLoading = false;
            }
        }
        #endregion
    }
}
