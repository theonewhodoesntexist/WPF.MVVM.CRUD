using CRUD.WPF.Models;
using CRUD.WPF.Services;
using CRUD.WPF.Stores.Records;
using System;
using System.Collections.ObjectModel;

namespace CRUD.WPF.ViewModels.Records
{
    public static class RecordsStorage
    {
        #region Properties
        public static ObservableCollection<RecordsListingItemViewModel> RecordsCollection { get; } = new ObservableCollection<RecordsListingItemViewModel>();
        #endregion

        #region Helper methods
        public static void InitializeRecords(StudentModelStore studentModelStore, NavigationManager navigationManager)
        {
            StudentModel studentModel1 = new StudentModel(Guid.NewGuid(), "Joan", "Doe", 24, "Female", true);
            StudentModel studentModel2 = new StudentModel(Guid.NewGuid(), "Johan", "Liebert", 22, "Male", true);
            StudentModel studentModel3 = new StudentModel(Guid.NewGuid(), "Jordan", "Faciol", 20, "Male", false);

            RecordsListingItemViewModel initialRecord1 = new RecordsListingItemViewModel(studentModel1, studentModelStore, navigationManager);
            RecordsListingItemViewModel initialRecord2 = new RecordsListingItemViewModel(studentModel2, studentModelStore, navigationManager);
            RecordsListingItemViewModel initialRecord3 = new RecordsListingItemViewModel(studentModel3, studentModelStore, navigationManager);

            RecordsCollection.Add(initialRecord1);
            RecordsCollection.Add(initialRecord2);
            RecordsCollection.Add(initialRecord3);
        }
        #endregion
    }
}
