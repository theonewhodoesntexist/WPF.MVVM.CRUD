namespace CRUD.WPF.ViewModels.Dashboard
{
    public class MaleStudentsViewModel : ViewModelBase
    {
        #region Properties
        public int MaleStudents { get; }
        #endregion

        #region Constructor
        public MaleStudentsViewModel()
        {
            MaleStudents = 33;
        }
        #endregion
    }
}
