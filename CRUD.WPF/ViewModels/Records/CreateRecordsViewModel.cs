using CRUD.WPF.Commands;
using CRUD.WPF.Commands.Records;
using CRUD.WPF.Services;
using CRUD.WPF.Stores.Records;
using System.Windows.Input;

namespace CRUD.WPF.ViewModels.Records
{
    public class CreateRecordsViewModel : ViewModelBase
    {
        #region Properties
        public RecordsDetailsFormViewModel RecordsDetailsFormViewModel { get; }

        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);
        public ICommand ErrorCommand { get; }
        #endregion

        #region Contructor
        public CreateRecordsViewModel(StudentModelStore studentModelStore, NavigationManager navigationManager)
        {
            ICommand submitCommand = new CreateRecordsCommand(
                studentModelStore,
                navigationManager.CreateCloseModalNavigationService(), 
                this);
            ICommand closeCommand = new CloseModalCommand(navigationManager.CreateCloseModalNavigationService());
            ErrorCommand = closeCommand;

            RecordsDetailsFormViewModel = new RecordsDetailsFormViewModel(submitCommand, closeCommand);
        }
        #endregion
    }
}
