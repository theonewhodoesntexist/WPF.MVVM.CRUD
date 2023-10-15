namespace CRUD.WPF.ViewModels.Dashboard
{
    public class FemaleStudentsViewModel : ViewModelBase
    {
        #region Properties
        public int FemaleStudents { get; }
        #endregion

        #region Constructor
        public FemaleStudentsViewModel()
        {
            FemaleStudents = 7;
        }
        #endregion
    }
}
