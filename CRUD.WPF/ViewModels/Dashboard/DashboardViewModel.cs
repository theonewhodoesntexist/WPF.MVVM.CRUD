using CRUD.WPF.Stores.Records;

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
        public DashboardViewModel(StudentModelStore studentModelStore)
        {
            TotalStudentsViewModel = new TotalStudentsViewModel(studentModelStore);
            MaleStudentsViewModel = new MaleStudentsViewModel(studentModelStore);
            FemaleStudentsViewModel = new FemaleStudentsViewModel(studentModelStore);
            OldestStudentViewModel = new OldestStudentViewModel(studentModelStore);
            YoungestStudentViewModel = new YoungestStudentViewModel(studentModelStore);
            OutstandingStudentsViewModel = new OutstandingStudentsViewModel(studentModelStore);
        }
        #endregion

        #region Dispose
        public override void Dispose()
        {
            TotalStudentsViewModel.Dispose();
            MaleStudentsViewModel.Dispose();
            FemaleStudentsViewModel.Dispose();
            OldestStudentViewModel.Dispose();
            YoungestStudentViewModel.Dispose();
            OutstandingStudentsViewModel.Dispose();

            base.Dispose();
        }
        #endregion
    }
}
