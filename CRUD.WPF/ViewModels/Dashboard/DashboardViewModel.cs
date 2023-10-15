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
        public DashboardViewModel()
        {
            TotalStudentsViewModel = new TotalStudentsViewModel();
            MaleStudentsViewModel = new MaleStudentsViewModel();
            FemaleStudentsViewModel = new FemaleStudentsViewModel();
            OldestStudentViewModel = new OldestStudentViewModel();
            YoungestStudentViewModel = new YoungestStudentViewModel();
            OutstandingStudentsViewModel = new OutstandingStudentsViewModel();
        }
        #endregion
    }
}
