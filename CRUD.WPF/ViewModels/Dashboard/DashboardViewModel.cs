using CRUD.WPF.Stores;
using CRUD.WPF.ViewModels.Layout;

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
        }
        #endregion
    }
}
