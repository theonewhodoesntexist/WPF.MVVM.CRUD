using CRUD.WPF.Commands;
using CRUD.WPF.Models;
using CRUD.WPF.Services;
using System.Windows.Input;

namespace CRUD.WPF.ViewModels.Records
{
    public class RecordsListingItemViewModel : ViewModelBase
    {
        #region Properties
        public StudentModel StudentModel { get; }
        public string FullName => $"{FirstName} {LastName}";
        public string FirstName => StudentModel.FirstName;
        public string LastName => StudentModel.LastName;
        public bool IsOutstanding => StudentModel.IsOutstanding;
        public ICommand OutstandingCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        #endregion

        #region Constructor
        public RecordsListingItemViewModel(StudentModel studentModel, INavigationService updateRecordsNavigationService)
        {
            StudentModel = studentModel;

            UpdateCommand = new NavigateCommand(updateRecordsNavigationService);
        }
        #endregion
    }
}
