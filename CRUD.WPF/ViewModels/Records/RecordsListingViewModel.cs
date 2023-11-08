using CRUD.WPF.Models;
using CRUD.WPF.Services;
using CRUD.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CRUD.WPF.ViewModels.Records
{
    public class RecordsListingViewModel : ViewModelBase
    {
        #region Fields
        private readonly ObservableCollection<RecordsListingItemViewModel> _recordsListingItemViewModel;
        private readonly SelectedStudentModelStore _selectedStudentModelStore;
        private readonly StudentModelStore _studentModelStore;
        private readonly NavigationStore _navigationStore;
        private readonly NavigationManager _navigationManager;
        #endregion

        #region Properties
        public IEnumerable<RecordsListingItemViewModel> RecordsListingItemViewModel => _recordsListingItemViewModel;

        private RecordsListingItemViewModel _selectedRecordsListingItemViewModel;
        public RecordsListingItemViewModel SelectedRecordsListingItemViewModel
        {
            get
            {
                return _selectedRecordsListingItemViewModel;
            }
            set
            {
                _selectedRecordsListingItemViewModel = value;
                OnPropertyChanged(nameof(SelectedRecordsListingItemViewModel));

                _selectedStudentModelStore.SelectedStudentModel = _selectedRecordsListingItemViewModel?.StudentModel;
            }
        }
        #endregion

        #region Constructor
        public RecordsListingViewModel(
            SelectedStudentModelStore selectedStudentModelStore,
            StudentModelStore studentModelStore,
            NavigationStore navigationStore,
            NavigationManager navigationManager)
        {
            _recordsListingItemViewModel = new ObservableCollection<RecordsListingItemViewModel>();
            _selectedStudentModelStore = selectedStudentModelStore;
            _studentModelStore = studentModelStore;
            _navigationStore = navigationStore;
            _navigationManager = navigationManager;

            _selectedStudentModelStore.SelectedStudentModelChanged += SelectedStudentModelStore_SelectedStudentModelChanged;
            _studentModelStore.StudentModelCreated += StudentModelStore_StudentModelCreated;
            _studentModelStore.StudentModelUpdated += StudentModelStore_StudentModelUpdated;
            _studentModelStore.StudentModelDeleted += StudentModelStore_StudentModelDeleted;
        }
        #endregion

        #region Subscribers
        private void SelectedStudentModelStore_SelectedStudentModelChanged()
        {
            OnPropertyChanged(nameof(SelectedRecordsListingItemViewModel));
        }

        private void StudentModelStore_StudentModelCreated(StudentModel studentModel)
        {
            CreateStudentModel(studentModel);
        }

        private void StudentModelStore_StudentModelUpdated(StudentModel studentModel)
        {
            RecordsListingItemViewModel foundStudentModel = FindStudentModel(studentModel);

            if (foundStudentModel != null)
            {
                foundStudentModel.Update(studentModel);
            }
        }

        private void StudentModelStore_StudentModelDeleted(StudentModel studentModel)
        {
            RecordsListingItemViewModel foundStudentModel = FindStudentModel(studentModel);

            if (foundStudentModel != null)
            {
                _recordsListingItemViewModel.Remove(foundStudentModel);
            } 
        }
        #endregion

        #region Dispose
        public override void Dispose()
        {
            _selectedStudentModelStore.SelectedStudentModelChanged -= SelectedStudentModelStore_SelectedStudentModelChanged;
            _studentModelStore.StudentModelCreated -= StudentModelStore_StudentModelCreated;
            _studentModelStore.StudentModelUpdated -= StudentModelStore_StudentModelUpdated;
            _studentModelStore.StudentModelDeleted -= StudentModelStore_StudentModelDeleted;

            base.Dispose();
        }
        #endregion

        #region Helper methods
        public void CreateStudentModel(StudentModel studentModel)
        {
            RecordsListingItemViewModel newStudentModel = new RecordsListingItemViewModel(studentModel, _studentModelStore, _navigationStore, _navigationManager);
            _recordsListingItemViewModel.Add(newStudentModel);
        }

        public RecordsListingItemViewModel FindStudentModel(StudentModel studentModel)
        {
            return _recordsListingItemViewModel.FirstOrDefault(r => r.StudentModel.Id == studentModel.Id);
        }
        #endregion
    }
}
