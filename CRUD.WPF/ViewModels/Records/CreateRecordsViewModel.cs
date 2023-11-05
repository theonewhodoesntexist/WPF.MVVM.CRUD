using CRUD.WPF.Commands;
using CRUD.WPF.Services;
using CRUD.WPF.Stores;
using System.Windows.Input;

namespace CRUD.WPF.ViewModels.Records
{
    public class CreateRecordsViewModel : ViewModelBase
    {
        #region Properties
        public RecordsDetailsFormViewModel RecordsDetailsFormViewModel { get; }
        #endregion

        #region Contructor
        public CreateRecordsViewModel(INavigationService closeModalNavigationService)
        {
            ICommand submitCommand = null;
            ICommand cancelCommand = new CloseModalCommand(closeModalNavigationService);

            RecordsDetailsFormViewModel = new RecordsDetailsFormViewModel(submitCommand, cancelCommand);
        }
        #endregion
    }
}
