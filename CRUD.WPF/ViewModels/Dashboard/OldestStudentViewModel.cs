namespace CRUD.WPF.ViewModels.Dashboard
{
    public class OldestStudentViewModel : ViewModelBase
    {
        #region Properties
        public string OldestStudentName { get; }
        public string OldestStudentAge { get; }
        #endregion

        #region Constructor
        public OldestStudentViewModel()
        {
            OldestStudentName = "John Doe";
            OldestStudentAge = "24 years old";
        }
        #endregion
    }
}
