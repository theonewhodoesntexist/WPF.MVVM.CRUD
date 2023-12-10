using CRUD.Domain.Models;
using CRUD.WPF.Components.Dashboard;
using CRUD.WPF.Stores.Records;
using System;
using System.Linq;

namespace CRUD.WPF.ViewModels.Dashboard
{
    public class MaleStudentsViewModel : ViewModelBase
    {
        #region Fields
        private readonly StudentModelStore _studentModelStore;
        #endregion

        #region Properties
        public int MaleStudents => _studentModelStore.StudentModel.Count(student => student.Sex == "Male");
        #endregion

        #region Constructor
        public MaleStudentsViewModel(StudentModelStore studentModelStore)
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
            OnPropertyChanged(nameof(MaleStudents));
        }

        private void StudentModelStore_StudentModelCreated(StudentModel obj)
        {
            OnPropertyChanged(nameof(MaleStudents));
        }

        private void StudentModelStore_StudentModelUpdated(StudentModel obj)
        {
            OnPropertyChanged(nameof(MaleStudents));
        }

        private void StudentModelStore_StudentModelDeleted(Guid obj)
        {
            OnPropertyChanged(nameof(MaleStudents));
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
