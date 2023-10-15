namespace CRUD.WPF.ViewModels.Dashboard
{
    public class TotalStudentsViewModel : ViewModelBase
    {
        #region Properties
        public int TotalStudents { get; }
        #endregion

        #region Constructor
        public TotalStudentsViewModel()
        {
            TotalStudents = 40;
        }
        #endregion
    }
}
