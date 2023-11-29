using CRUD.Domain.Models;
using CRUD.WPF.Stores.Records;
using CRUD.WPF.ViewModels.Records;
using System;
using System.Threading.Tasks;

namespace CRUD.WPF.Commands.Records
{
    public class OutstandingStudentCommand : AsyncCommandBase
    {
        #region Fields
        private readonly StudentModelStore _studentModelStore;
        private readonly RecordsListingItemViewModel _recordsListingItemViewModel;
        #endregion

        #region Contructor
        public OutstandingStudentCommand(StudentModelStore studentModelStore, RecordsListingItemViewModel recordsListingItemViewModel)
        {
            _studentModelStore = studentModelStore;
            _recordsListingItemViewModel = recordsListingItemViewModel;
        }
        #endregion

        #region AsyncCommandBase
        public override async Task ExecuteAsync(object? parameter)
        {
            StudentModel studentModel = _recordsListingItemViewModel.StudentModel;
            try
            {
                await _studentModelStore.Outstanding(studentModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
