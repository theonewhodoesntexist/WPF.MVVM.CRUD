using CRUD.WPF.Services;

namespace CRUD.WPF.Commands
{
    public class CloseModalCommand : CommandBase
    {
        #region Fields
        private readonly INavigationService _closeModalNavigationService;
        #endregion

        #region Constructor
        public CloseModalCommand(INavigationService closeModalNavigationService)
        {
            _closeModalNavigationService = closeModalNavigationService;
        }
        #endregion

        #region CommandBase
        public override void Execute(object? parameter)
        {
            _closeModalNavigationService.Navigate();
        }
        #endregion
    }
}
