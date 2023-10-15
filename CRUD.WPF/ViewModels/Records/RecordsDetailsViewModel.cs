namespace CRUD.WPF.ViewModels.Records
{
    public class RecordsDetailsViewModel : ViewModelBase
    {
        #region Properties
        public string FirstName { get; }
        public string LastName { get; }
        public int Age { get; }
        public string Sex { get; }
        #endregion

        #region Constructor
        public RecordsDetailsViewModel()
        {
            FirstName = "John";
            LastName = "Doe";
            Age = 20;
            Sex = "Male";
        }
        #endregion
    }
}
