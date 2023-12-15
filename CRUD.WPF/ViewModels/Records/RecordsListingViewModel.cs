using CRUD.Domain.Models;
using CRUD.WPF.Services;
using CRUD.WPF.Stores.Accounts;
using CRUD.WPF.Stores.Records;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CRUD.WPF.ViewModels.Records
{
    public class RecordsListingViewModel : ViewModelBase
    {
        #region Fields
        private readonly ObservableCollection<RecordsListingItemViewModel> _recordsListingItemViewModel;
        private readonly SelectedStudentModelStore _selectedStudentModelStore;
        private readonly StudentModelStore _studentModelStore;
        private readonly NavigationManager _navigationManager;
        private readonly AccountStore _accountStore;
        #endregion

        #region Properties
        public IEnumerable<RecordsListingItemViewModel> RecordsListingItemViewModel => _recordsListingItemViewModel;

        public RecordsListingItemViewModel SelectedRecordsListingItemViewModel
        {
            get
            {
                return _recordsListingItemViewModel
                    .FirstOrDefault(record => record.StudentModel?.Id == _selectedStudentModelStore.SelectedStudentModel?.Id);
            }
            set
            {
                _selectedStudentModelStore.SelectedStudentModel = value?.StudentModel;
            }
        }
        #endregion

        #region Constructor
        public RecordsListingViewModel(
            SelectedStudentModelStore selectedStudentModelStore,
            StudentModelStore studentModelStore,
            NavigationManager navigationManager,
            AccountStore accountStore)
        {
            _recordsListingItemViewModel = new ObservableCollection<RecordsListingItemViewModel>();
            _selectedStudentModelStore = selectedStudentModelStore;
            _studentModelStore = studentModelStore;
            _navigationManager = navigationManager;
            _accountStore = accountStore;

            _selectedStudentModelStore.SelectedStudentModelChanged += SelectedStudentModelStore_SelectedStudentModelChanged;
            _studentModelStore.StudentModelLoaded += StudentModelStore_StudentModelLoaded;
            _studentModelStore.StudentModelCreated += StudentModelStore_StudentModelCreated;
            _studentModelStore.StudentModelUpdated += StudentModelStore_StudentModelUpdated;
            _studentModelStore.StudentModelDeleted += StudentModelStore_StudentModelDeleted;
            _recordsListingItemViewModel.CollectionChanged += RecordsListingItemViewModel_CollectionChanged;
        }
        #endregion

        #region Subscribers
        private void RecordsListingItemViewModel_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(SelectedRecordsListingItemViewModel));
        }

        private void SelectedStudentModelStore_SelectedStudentModelChanged()
        {
            OnPropertyChanged(nameof(SelectedRecordsListingItemViewModel));
        }

        private void StudentModelStore_StudentModelLoaded()
        {
            _recordsListingItemViewModel.Clear();

            foreach (StudentModel studentModel in _studentModelStore.StudentModel)
            {
                CreateStudentModel(studentModel);
            }
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

        private void StudentModelStore_StudentModelDeleted(Guid id)
        {
            RecordsListingItemViewModel foundStudentModel = _recordsListingItemViewModel.FirstOrDefault(records => records.StudentModel.Id == id);

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
            _studentModelStore.StudentModelLoaded -= StudentModelStore_StudentModelLoaded;
            _studentModelStore.StudentModelCreated -= StudentModelStore_StudentModelCreated;
            _studentModelStore.StudentModelUpdated -= StudentModelStore_StudentModelUpdated;
            _studentModelStore.StudentModelDeleted -= StudentModelStore_StudentModelDeleted;
            _recordsListingItemViewModel.CollectionChanged -= RecordsListingItemViewModel_CollectionChanged;
            SelectedRecordsListingItemViewModel?.Dispose();

            base.Dispose();
        }
        #endregion

        #region Helper methods
        public void CreateStudentModel(StudentModel studentModel)
        {
            RecordsListingItemViewModel newRecord = new RecordsListingItemViewModel(
                studentModel,
                _studentModelStore,
                _navigationManager,
                _accountStore);
            _recordsListingItemViewModel.Add(newRecord);
        }

        public RecordsListingItemViewModel FindStudentModel(StudentModel studentModel)
        {
            return _recordsListingItemViewModel.FirstOrDefault(records => records.StudentModel.Id == studentModel.Id);
        }
        #endregion
    }
}
