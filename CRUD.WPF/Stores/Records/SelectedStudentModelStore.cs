using CRUD.Domain.Models;
using CRUD.WPF.ViewModels;
using System;

namespace CRUD.WPF.Stores.Records
{
    public class SelectedStudentModelStore
    {
        #region Fields
        private readonly StudentModelStore _studentModelStore;
        #endregion

        #region Properties
        private StudentModel _selectedStudentModel;
        public StudentModel SelectedStudentModel
        {
            get
            {
                return _selectedStudentModel;
            }
            set
            {
                _selectedStudentModel = value;
                SelectedStudentModelChanged?.Invoke();
            }
        }
        #endregion

        #region Constructor
        public SelectedStudentModelStore(StudentModelStore studentModelStore)
        {
            _studentModelStore = studentModelStore;

            _studentModelStore.StudentModelCreated += StudentModelStore_StudentModelCreated;
            _studentModelStore.StudentModelUpdated += StudentModelStore_StudentModelUpdated;
            _studentModelStore.StudentModelDeleted += StudentModelStore_StudentModelDeleted;
        }
        #endregion

        #region Events
        public event Action SelectedStudentModelChanged;
        #endregion

        #region Subscribers
        private void StudentModelStore_StudentModelCreated(StudentModel studentModel)
        {
            SelectedStudentModel = studentModel;
        }

        private void StudentModelStore_StudentModelUpdated(StudentModel studentModel)
        {
            SelectedStudentModel = studentModel;
        }

        private void StudentModelStore_StudentModelDeleted(StudentModel studentModel)
        {
            studentModel = null;
            SelectedStudentModel = studentModel;
        }
        #endregion
    }
}
