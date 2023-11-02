namespace CRUD.WPF.ViewModels.Records
{
    public class CreateRecordsViewModel : ViewModelBase
    {
        #region Properties
        public RecordsDetailsFormViewModel RecordsDetailsFormViewModel { get; }
        #endregion

        #region Contructor
        public CreateRecordsViewModel()
        {
            RecordsDetailsFormViewModel = new RecordsDetailsFormViewModel();
        }
        #endregion
    }
}
