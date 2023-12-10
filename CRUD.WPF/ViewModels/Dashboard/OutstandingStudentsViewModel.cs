using CRUD.Domain.Models;
using CRUD.WPF.Stores.Records;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUD.WPF.ViewModels.Dashboard
{
    public class OutstandingStudentsViewModel : ViewModelBase
    {
        #region Fields
        private readonly StudentModelStore _studentModelStore;
        #endregion

        #region Properties
        public IEnumerable<StudentModel> OutstandingStudents => _studentModelStore?.StudentModel
            .Where(student => student.IsOutstanding == true);
        #endregion

        #region Constructor
        public OutstandingStudentsViewModel(StudentModelStore studentModelStore)
        {
            _studentModelStore = studentModelStore;

            _studentModelStore.StudentModelLoaded += StudentModelStore_StudentModelLoaded;
            _studentModelStore.StudentModelCreated += StudentModelStore_StudentModelCreated;
            _studentModelStore.StudentModelUpdated += StudentModelStore_StudentModelUpdated;
            _studentModelStore.StudentModelDeleted += StudentModelStore_StudentModelDeleted;
        }
        #endregion

        #region Helper methods
        private void StudentModelStore_StudentModelLoaded()
        {
            OnPropertyChanged(nameof(OutstandingStudents));
        }

        private void StudentModelStore_StudentModelCreated(StudentModel obj)
        {
            OnPropertyChanged(nameof(OutstandingStudents));
        }

        private void StudentModelStore_StudentModelUpdated(StudentModel obj)
        {
            OnPropertyChanged(nameof(OutstandingStudents));
        }

        private void StudentModelStore_StudentModelDeleted(Guid obj)
        {
            OnPropertyChanged(nameof(OutstandingStudents));
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
