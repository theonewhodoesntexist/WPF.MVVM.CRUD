using CRUD.WPF.Commands;
using CRUD.WPF.Services;
using CRUD.WPF.Stores;
using CRUD.WPF.ViewModels.Account;
using CRUD.WPF.ViewModels.Records;
using System.Windows.Input;

namespace CRUD.WPF.ViewModels.Dashboard
{
    public class DashboardViewModel : ViewModelBase
    {
        #region Fields
        private readonly NavigationStore _navigationStore;
        private readonly AccountStore _accountStore;
        #endregion

        #region Properties
        public TotalStudentsViewModel TotalStudentsViewModel { get; }
        public MaleStudentsViewModel MaleStudentsViewModel { get; }
        public FemaleStudentsViewModel FemaleStudentsViewModel { get; }
        public OldestStudentViewModel OldestStudentViewModel { get; }
        public YoungestStudentViewModel YoungestStudentViewModel { get; }
        public OutstandingStudentsViewModel OutstandingStudentsViewModel { get; }
        public ICommand NavigateAccountCommand { get; }
        public ICommand NavigateRecordsCommand { get; }
        #endregion

        #region Constructor
        public DashboardViewModel(NavigationStore navigationStore, AccountStore accountStore)
        {
            TotalStudentsViewModel = new TotalStudentsViewModel();
            MaleStudentsViewModel = new MaleStudentsViewModel();
            FemaleStudentsViewModel = new FemaleStudentsViewModel();
            OldestStudentViewModel = new OldestStudentViewModel();
            YoungestStudentViewModel = new YoungestStudentViewModel();
            OutstandingStudentsViewModel = new OutstandingStudentsViewModel();

            _navigationStore = navigationStore;
            _accountStore = accountStore;
            NavigateAccountCommand = new NavigateCommand<AccountViewModel>(new NavigationService<AccountViewModel>(_navigationStore, () => new AccountViewModel(_navigationStore, _accountStore)));
            NavigateRecordsCommand = new NavigateCommand<RecordsViewModel>(new NavigationService<RecordsViewModel>(_navigationStore, () => new RecordsViewModel(_navigationStore, _accountStore)));
        }
        #endregion
    }
}
