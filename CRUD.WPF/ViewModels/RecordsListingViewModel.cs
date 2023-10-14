using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CRUD.WPF.ViewModels
{
    public class RecordsListingViewModel : ViewModelBase
    {
        #region Fields
        private readonly ObservableCollection<RecordsListingItemViewModel> _recordsListingItemViewModel;
        #endregion

        #region Properties
        public IEnumerable<RecordsListingItemViewModel> RecordsListingItemViewModel => _recordsListingItemViewModel;
        #endregion

        #region Constructor
        public RecordsListingViewModel()
        {
            _recordsListingItemViewModel = new ObservableCollection<RecordsListingItemViewModel>();

            _recordsListingItemViewModel.Add(new RecordsListingItemViewModel("John", "Doe"));
            _recordsListingItemViewModel.Add(new RecordsListingItemViewModel("Johan", "Liebert"));
            _recordsListingItemViewModel.Add(new RecordsListingItemViewModel("Jordan", "Faciol"));
        }
        #endregion
    }
}
