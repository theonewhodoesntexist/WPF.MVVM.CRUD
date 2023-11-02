namespace CRUD.WPF.ViewModels.Records
{
    public class UpdateRecordsViewModel : ViewModelBase
    {
        #region Properties
        public RecordsDetailsFormViewModel RecordsDetailsFormViewModel { get; }
        #endregion

        #region Contructor
        public UpdateRecordsViewModel()
        {
            RecordsDetailsFormViewModel = new RecordsDetailsFormViewModel();
        }
        #endregion
    }
}
