using CRUD.WPF.Services;

namespace CRUD.WPF.Commands
{
    public class NavigateCommand : CommandBase
    {
        #region Fields
        private readonly INavigationService _navigationService;
        #endregion

        #region Constructor
        public NavigateCommand(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        #endregion

        #region CommandBase
        public override void Execute(object? parameter)
        {
            _navigationService.Navigate();
        }
        #endregion
    }
}
