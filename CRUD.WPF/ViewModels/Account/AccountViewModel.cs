using CRUD.WPF.Commands;
using CRUD.WPF.Stores;
using CRUD.WPF.ViewModels.Dashboard;
using CRUD.WPF.ViewModels.Records;
using System.Windows.Input;

namespace CRUD.WPF.ViewModels.Account
{
    public class AccountViewModel : ViewModelBase
    {
        #region Fields
        private readonly NavigationStore _navigationStore;
        #endregion

        #region Properties
        public string Username { get; }
        public string Name { get; }
        public ICommand EditAccountCommand { get; }
        public ICommand NavigateDashboardCommand { get; }
        public ICommand NavigateRecordsCommand { get; }
        #endregion

        #region Constructor
        public AccountViewModel(NavigationStore navigationStore)
        {
            Username = "moriarity99";
            Name = "Jim Moriarity";

            _navigationStore = navigationStore;
            NavigateDashboardCommand = new NavigateCommand<DashboardViewModel>(_navigationStore, () => new DashboardViewModel(_navigationStore));
            NavigateRecordsCommand = new NavigateCommand<RecordsViewModel>(_navigationStore, () => new RecordsViewModel(_navigationStore));
        }
        #endregion
    }
}
