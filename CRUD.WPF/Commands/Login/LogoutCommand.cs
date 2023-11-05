using CRUD.WPF.Services;
using CRUD.WPF.Stores;

namespace CRUD.WPF.Commands.Login
{
    public class LogoutCommand : CommandBase
    {
        #region Fields
        private readonly AccountStore _accountStore;
        private readonly INavigationService _recordsNavigationService;
        #endregion

        #region Constructor
        public LogoutCommand(AccountStore accountStore, INavigationService recordsNavigationService)
        {
            _accountStore = accountStore;
            _recordsNavigationService = recordsNavigationService;
        }
        #endregion

        #region CommandBase
        public override void Execute(object? parameter)
        {
            _accountStore.Logout();
            _recordsNavigationService.Navigate();
        }
        #endregion
    }
}
