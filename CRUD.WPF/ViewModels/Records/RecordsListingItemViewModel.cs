using CRUD.WPF.Commands;
using CRUD.WPF.Commands.Records;
using CRUD.WPF.Models;
using CRUD.WPF.Services;
using CRUD.WPF.Stores;
using System.Windows.Input;

namespace CRUD.WPF.ViewModels.Records
{
    public class RecordsListingItemViewModel : ViewModelBase
    {
        #region Fields
        private readonly StudentModelStore _studentModelStore;
        private readonly NavigationManager _navigationManager;
        #endregion

        #region Properties
        public StudentModel StudentModel { get; private set; }
        public string FullName => $"{FirstName} {LastName}";
        public string FirstName => StudentModel.FirstName;
        public string LastName => StudentModel.LastName;
        public bool IsOutstanding => StudentModel.IsOutstanding;
        public ICommand OutstandingCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        #endregion

        #region Constructor
        public RecordsListingItemViewModel(
            StudentModel studentModel,
            StudentModelStore studentModelStore, 
            NavigationManager navigationManager)
        {
            StudentModel = studentModel;
            _studentModelStore = studentModelStore;
            _navigationManager = navigationManager;

            UpdateCommand = new NavigateCommand(_navigationManager.CreateModalNavigationService(
                () => new UpdateRecordsViewModel(
                    this,
                    _studentModelStore, 
                    _navigationManager)));
            DeleteCommand = new DeleteRecordsCommand(this, _studentModelStore);
        }
        #endregion

        #region Helper methods
        public void Update(StudentModel studentModel)
        {
            StudentModel = studentModel;

            OnPropertyChanged(nameof(FullName));
            OnPropertyChanged(nameof(FirstName));
            OnPropertyChanged(nameof(LastName));
        }
        #endregion
    }
}
