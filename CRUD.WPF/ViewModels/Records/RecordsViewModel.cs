namespace CRUD.WPF.ViewModels.Records
{
    public class RecordsViewModel : ViewModelBase
    {
        #region Properties
        public RecordsListingViewModel RecordsListingViewModel { get; }
        public RecordsDetailsViewModel RecordsDetailsViewModel { get; }
        #endregion

        #region Constructor
        public RecordsViewModel()
        {
            RecordsListingViewModel = new RecordsListingViewModel();
            RecordsDetailsViewModel = new RecordsDetailsViewModel();
        }
        #endregion
    }
}
