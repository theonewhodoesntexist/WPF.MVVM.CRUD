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
        #endregion

        #region Contructor
        public CreateRecordsViewModel(StudentModelStore studentModelStore, NavigationManager navigationManager)
        {
            ICommand submitCommand = new CreateRecordsCommand(studentModelStore, navigationManager.CreateCloseModalNavigationService(), this);
            ICommand cancelCommand = new CloseModalCommand(navigationManager.CreateCloseModalNavigationService());

            RecordsDetailsFormViewModel = new RecordsDetailsFormViewModel(submitCommand, cancelCommand);
        }
        #endregion
    }
}
