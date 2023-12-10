﻿using CRUD.Domain.Models;
using CRUD.WPF.Components.Dashboard;
using CRUD.WPF.Stores.Records;
using System;
using System.Linq;

namespace CRUD.WPF.ViewModels.Dashboard
{
    public class FemaleStudentsViewModel : ViewModelBase
    {
        #region Fields
        private readonly StudentModelStore _studentModelStore;
        #endregion

        #region Properties
        public int FemaleStudents => _studentModelStore.StudentModel.Count(student => student.Sex == "Female");
        #endregion

        #region Constructor
        public FemaleStudentsViewModel(StudentModelStore studentModelStore)
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
            OnPropertyChanged(nameof(FemaleStudents));
        }

        private void StudentModelStore_StudentModelCreated(StudentModel obj)
        {
            OnPropertyChanged(nameof(FemaleStudents));
        }

        private void StudentModelStore_StudentModelUpdated(StudentModel obj)
        {
            OnPropertyChanged(nameof(FemaleStudents));
        }

        private void StudentModelStore_StudentModelDeleted(Guid obj)
        {
            OnPropertyChanged(nameof(FemaleStudents));
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
