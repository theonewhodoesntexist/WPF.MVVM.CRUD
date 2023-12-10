using CRUD.Domain.Models;
using CRUD.WPF.Stores.Records;
using System;
using System.Linq;

namespace CRUD.WPF.ViewModels.Dashboard
{
    public class OldestStudentViewModel : ViewModelBase
    {
        #region Fields
        private readonly StudentModelStore _studentModelStore;
        #endregion

        #region Properties
        public StudentModel StudentModel => _studentModelStore.StudentModel
            .Where(student => student.Age > 0)
            .OrderByDescending(student => student.Age)
            .FirstOrDefault();
        public string FirstName => StudentModel?.FirstName ?? "None";
        public string LastName => StudentModel?.FirstName ?? string.Empty;
        public string OldestStudentName => $"{FirstName} {LastName}";
        public string OldestStudentAge
        {
            get
            {
                int? age = StudentModel?.Age ?? 0;
                return age.Value > 0? $"{age} years old" : string.Empty;
            }
        }
        #endregion

        #region Constructor
        public OldestStudentViewModel(StudentModelStore studentModelStore)
        {
            _studentModelStore = studentModelStore;

            _studentModelStore.StudentModelLoaded += StudentModelStore_StudentModelLoaded;
            _studentModelStore.StudentModelCreated += StudentModelStore_StudentModelCreated;
            _studentModelStore.StudentModelUpdated += StudentModelStore_StudentModelUpdated;
            _studentModelStore.StudentModelDeleted += StudentModelStore_StudentModelDeleted;
        }
        #endregion

        #region Subscribers
        private void StudentModelStore_StudentModelLoaded()
        {
            OnPropertyChanged(nameof(StudentModel));
            OnPropertyChanged(nameof(FirstName));
            OnPropertyChanged(nameof(LastName));
            OnPropertyChanged(nameof(OldestStudentName));
            OnPropertyChanged(nameof(OldestStudentAge));
        }

        private void StudentModelStore_StudentModelCreated(StudentModel obj)
        {
            OnPropertyChanged(nameof(StudentModel));
            OnPropertyChanged(nameof(FirstName));
            OnPropertyChanged(nameof(LastName));
            OnPropertyChanged(nameof(OldestStudentName));
            OnPropertyChanged(nameof(OldestStudentAge));
        }

        private void StudentModelStore_StudentModelUpdated(StudentModel obj)
        {
            OnPropertyChanged(nameof(StudentModel));
            OnPropertyChanged(nameof(FirstName));
            OnPropertyChanged(nameof(LastName));
            OnPropertyChanged(nameof(OldestStudentName));
            OnPropertyChanged(nameof(OldestStudentAge));
        }

        private void StudentModelStore_StudentModelDeleted(Guid obj)
        {
            OnPropertyChanged(nameof(StudentModel));
            OnPropertyChanged(nameof(FirstName));
            OnPropertyChanged(nameof(LastName));
            OnPropertyChanged(nameof(OldestStudentName));
            OnPropertyChanged(nameof(OldestStudentAge));
        }
        #endregion

        #region Dispose
        public override void Dispose()
        {
            _studentModelStore.StudentModelLoaded -= StudentModelStore_StudentModelLoaded;
            _studentModelStore.StudentModelCreated -= StudentModelStore_StudentModelCreated;
            _studentModelStore.StudentModelUpdated -= StudentModelStore_StudentModelUpdated;
            _studentModelStore.StudentModelDeleted -= StudentModelStore_StudentModelDeleted;

            base.Dispose();
        }
        #endregion
    }
}
