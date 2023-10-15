namespace CRUD.WPF.ViewModels.Dashboard
{
    public class YoungestStudentViewModel : ViewModelBase
    {
        #region Properties
        public string YoungestStudentName { get; }
        public string YoungestStudentAge { get; }
        #endregion

        #region Constructor
        public YoungestStudentViewModel()
        {
            YoungestStudentName = "Jordan Faciol";
            YoungestStudentAge = "20 years old";
        }
        #endregion
    }
}
