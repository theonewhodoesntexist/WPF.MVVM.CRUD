using System.Windows.Input;

namespace CRUD.WPF.ViewModels.Records
{
    public class RecordsListingItemViewModel : ViewModelBase
    {
        #region Properties
        public string FullName => $"{FirstName} {LastName}";
        public string FirstName { get; }
        public string LastName { get; }
        public bool IsOutstanding { get; }
        public ICommand OutstandingCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        #endregion

        #region Constructor
        public RecordsListingItemViewModel(string firstName, string lastName, bool isOutstanding)
        {
            FirstName = firstName;
            LastName = lastName;
            IsOutstanding = isOutstanding;
        }
        #endregion
    }
}
