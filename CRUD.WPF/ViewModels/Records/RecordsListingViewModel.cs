using CRUD.WPF.Models;
using CRUD.WPF.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CRUD.WPF.ViewModels.Records
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
        public RecordsListingViewModel(INavigationService updateRecordsNavigationService)
        {
            _recordsListingItemViewModel = new ObservableCollection<RecordsListingItemViewModel>();

            StudentModel studentModel = new StudentModel("John", "Doe", 24, "Male", true);
            _recordsListingItemViewModel.Add(new RecordsListingItemViewModel(studentModel, updateRecordsNavigationService));
        }
        #endregion
    }
}
