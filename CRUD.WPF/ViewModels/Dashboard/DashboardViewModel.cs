using CRUD.WPF.Stores;
using CRUD.WPF.Stores.Dashboard;

namespace CRUD.WPF.ViewModels.Dashboard
{
    public class DashboardViewModel : ViewModelBase
    {
        #region Properties
        public TotalStudentsViewModel TotalStudentsViewModel { get; }
        public MaleStudentsViewModel MaleStudentsViewModel { get; }
        public FemaleStudentsViewModel FemaleStudentsViewModel { get; }
        public OldestStudentViewModel OldestStudentViewModel { get; }
        public YoungestStudentViewModel YoungestStudentViewModel { get; }
        public OutstandingStudentsViewModel OutstandingStudentsViewModel { get; }
        #endregion

        #region Constructor
        public DashboardViewModel(DashboardStudentsStores dashboardStudentsStores)
        {
            TotalStudentsViewModel = new TotalStudentsViewModel(dashboardStudentsStores);
            MaleStudentsViewModel = new MaleStudentsViewModel(dashboardStudentsStores);
            FemaleStudentsViewModel = new FemaleStudentsViewModel(dashboardStudentsStores);
            OldestStudentViewModel = new OldestStudentViewModel(dashboardStudentsStores);
            YoungestStudentViewModel = new YoungestStudentViewModel(dashboardStudentsStores);
            OutstandingStudentsViewModel = new OutstandingStudentsViewModel();
        }
        #endregion
    }
}
