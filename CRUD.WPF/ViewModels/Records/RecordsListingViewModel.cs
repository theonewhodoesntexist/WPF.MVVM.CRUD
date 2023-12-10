using CRUD.Domain.Models;
using CRUD.WPF.Commands.Records;
using CRUD.WPF.Services;
using CRUD.WPF.Stores.Accounts;
using CRUD.WPF.Stores.Records;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

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

        public ICommand LoadRecordsCommand { get; }
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

            LoadRecordsCommand = new LoadRecordsCommand(_studentModelStore);

            _studentModelStore.StudentModelLoaded += StudentModelStore_StudentModelLoaded;
            _studentModelStore.StudentModelCreated += StudentModelStore_StudentModelCreated;
            _studentModelStore.StudentModelUpdated += StudentModelStore_StudentModelUpdated;
            _studentModelStore.StudentModelDeleted += StudentModelStore_StudentModelDeleted;
        }
        #endregion

        #region Subscribers
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
            _studentModelStore.StudentModelLoaded -= StudentModelStore_StudentModelLoaded;
            _studentModelStore.StudentModelCreated -= StudentModelStore_StudentModelCreated;
            _studentModelStore.StudentModelUpdated -= StudentModelStore_StudentModelUpdated;
            _studentModelStore.StudentModelDeleted -= StudentModelStore_StudentModelDeleted;
            _selectedRecordsListingItemViewModel?.Dispose();

            base.Dispose();
        }
        #endregion

        #region Helper methods
        public static RecordsListingViewModel LoadViewModel(
            SelectedStudentModelStore selectedStudentModelStore,
            StudentModelStore studentModelStore,
            NavigationManager navigationManager,
            AccountStore accountStore)
        {
            RecordsListingViewModel recordsListingViewModel = new RecordsListingViewModel(
                selectedStudentModelStore,
                studentModelStore,
                navigationManager,
                accountStore);

            recordsListingViewModel.LoadRecordsCommand.Execute(null);

            return recordsListingViewModel;
        }

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
