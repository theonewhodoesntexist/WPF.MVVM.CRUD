using CRUD.WPF.Commands;
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
        public DashboardViewModel(NavigationStore navigationStore)
        {
            TotalStudentsViewModel = new TotalStudentsViewModel();
            MaleStudentsViewModel = new MaleStudentsViewModel();
            FemaleStudentsViewModel = new FemaleStudentsViewModel();
            OldestStudentViewModel = new OldestStudentViewModel();
            YoungestStudentViewModel = new YoungestStudentViewModel();
            OutstandingStudentsViewModel = new OutstandingStudentsViewModel();

            _navigationStore = navigationStore;
            NavigateAccountCommand = new NavigateCommand<AccountViewModel>(_navigationStore, () => new AccountViewModel(_navigationStore));
            NavigateRecordsCommand = new NavigateCommand<RecordsViewModel>(_navigationStore, () => new RecordsViewModel(_navigationStore));
        }
        #endregion
    }
}
