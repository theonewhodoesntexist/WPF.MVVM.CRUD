using CRUD.Domain.Models;
using CRUD.WPF.Services;
using CRUD.WPF.Stores.Accounts;
using CRUD.WPF.Stores.Dashboard;
using CRUD.WPF.Stores.Records;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CRUD.WPF.ViewModels.Records
{
    public class RecordsListingViewModel : ViewModelBase
    {
        #region Fields
        private readonly ObservableCollection<RecordsListingItemViewModel> _recordsListingItemViewModel = RecordsStorage.RecordsCollection;
        private readonly SelectedStudentModelStore _selectedStudentModelStore;
        private readonly StudentModelStore _studentModelStore;
        private readonly NavigationManager _navigationManager;
        private readonly DashboardStudentsStores _dashboardStudentsStores;
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
        #endregion

        #region Constructor
        public RecordsListingViewModel(
            SelectedStudentModelStore selectedStudentModelStore,
            StudentModelStore studentModelStore,
            NavigationManager navigationManager,
            DashboardStudentsStores dashboardStudentsStores,
            AccountStore accountStore)
        {
            _selectedStudentModelStore = selectedStudentModelStore;
            _studentModelStore = studentModelStore;
            _navigationManager = navigationManager;
            _dashboardStudentsStores = dashboardStudentsStores;
            _accountStore = accountStore;

            UpdateDashboard();

            _studentModelStore.StudentModelCreated += StudentModelStore_StudentModelCreated;
            _studentModelStore.StudentModelUpdated += StudentModelStore_StudentModelUpdated;
            _studentModelStore.StudentModelDeleted += StudentModelStore_StudentModelDeleted;
            _studentModelStore.StudentModelOutstanding += StudentModelStore_StudentModelOutstanding;
        }
        #endregion

        #region Subscribers
        private void StudentModelStore_StudentModelCreated(StudentModel studentModel)
        {
            RecordsListingItemViewModel foundStudentModel = FindStudentModel(studentModel);

            if (foundStudentModel == null)
            {
                RecordsListingItemViewModel newStudentModel = new RecordsListingItemViewModel(
                    studentModel,
                    _studentModelStore,
                    _navigationManager,
                    _accountStore);
                _recordsListingItemViewModel.Add(newStudentModel);
                UpdateDashboard();
            }
        }

        private void StudentModelStore_StudentModelUpdated(StudentModel studentModel)
        {
            RecordsListingItemViewModel foundStudentModel = FindStudentModel(studentModel);

            if (foundStudentModel != null)
            {
                foundStudentModel.Update(studentModel);
                UpdateDashboard();
            }
        }

        private void StudentModelStore_StudentModelDeleted(StudentModel studentModel)
        {
            RecordsListingItemViewModel foundStudentModel = FindStudentModel(studentModel);

            if (foundStudentModel != null)
            {
                _recordsListingItemViewModel.Remove(foundStudentModel);
                UpdateDashboard();
            } 
        }

        private void StudentModelStore_StudentModelOutstanding(StudentModel studentModel)
        {
            RecordsListingItemViewModel foundStudentModel = FindStudentModel(studentModel);

            if (foundStudentModel != null)
            {
                foundStudentModel.Outstanding(studentModel);
            }
        }
        #endregion

        #region Dispose
        public override void Dispose()
        {
            _studentModelStore.StudentModelCreated -= StudentModelStore_StudentModelCreated;
            _studentModelStore.StudentModelUpdated -= StudentModelStore_StudentModelUpdated;
            _studentModelStore.StudentModelDeleted -= StudentModelStore_StudentModelDeleted;
            _studentModelStore.StudentModelOutstanding -= StudentModelStore_StudentModelOutstanding;
            _selectedRecordsListingItemViewModel?.Dispose();

            base.Dispose();
        }
        #endregion

        #region Helper methods
        public RecordsListingItemViewModel FindStudentModel(StudentModel studentModel)
        {
            return _recordsListingItemViewModel.FirstOrDefault(records => records.StudentModel.Id == studentModel.Id);
        }

        public void UpdateDashboard()
        {
            _dashboardStudentsStores.TotalStudents = _recordsListingItemViewModel.Count;

            int maleStudentsCount = _recordsListingItemViewModel.Count(record => record.StudentModel.Sex == "Male");
            _dashboardStudentsStores.MaleStudents = maleStudentsCount;

            int femaleStudentsCount = _recordsListingItemViewModel.Count(record => record.StudentModel.Sex == "Female");
            _dashboardStudentsStores.FemaleStudents = femaleStudentsCount;

            var oldestStudent = _recordsListingItemViewModel
                    .OrderByDescending(record => record.StudentModel.Age)
                    .FirstOrDefault();
            if (oldestStudent != null)
            {
                _dashboardStudentsStores.OldestStudentName = oldestStudent.FullName;
                _dashboardStudentsStores.OldestStudentAge = oldestStudent.StudentModel.Age;
            }

            var youngestStudent = _recordsListingItemViewModel
                .OrderBy(record => record.StudentModel.Age)
                .FirstOrDefault();
            if (youngestStudent != null)
            {
                _dashboardStudentsStores.YoungestStudentName = youngestStudent.FullName;
                _dashboardStudentsStores.YoungestStudentAge = youngestStudent.StudentModel.Age;
            }
        }
        #endregion
    }
}
