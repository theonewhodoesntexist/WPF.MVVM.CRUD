using CRUD.WPF.Services;
using CRUD.WPF.Stores;
using CRUD.WPF.ViewModels;
using System;

namespace CRUD.WPF.Commands
{
    public class NavigateCommand<TViewModel> : CommandBase
        where TViewModel : ViewModelBase
    {
        #region Fields
        private readonly INavigationService<TViewModel> _navigationService;
        #endregion

        #region Constructor
        public NavigateCommand(INavigationService<TViewModel> navigationService)
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
