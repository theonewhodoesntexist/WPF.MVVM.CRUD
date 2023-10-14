using System.Windows.Input;

namespace CRUD.WPF.ViewModels
{
    public class RecordsListingItemViewModel : ViewModelBase
    {
        #region Properties
        public string FullName => $"{FirstName} {LastName}";
        public string FirstName { get; }
        public string LastName { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        #endregion

        #region Constructor
        public RecordsListingItemViewModel(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        #endregion
    }
}
