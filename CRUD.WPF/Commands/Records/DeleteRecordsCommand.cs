using CRUD.Domain.Models;
using CRUD.WPF.Stores.Records;
using CRUD.WPF.ViewModels.Records;
using System;
using System.Threading.Tasks;

namespace CRUD.WPF.Commands.Records
{
    public class DeleteRecordsCommand : AsyncCommandBase
    {
        #region Fields
        private readonly RecordsListingItemViewModel _recordsListingItemViewModel;
        private readonly StudentModelStore _studentModelStore;
        #endregion

        #region Constructor
        public DeleteRecordsCommand(RecordsListingItemViewModel recordsListingItemViewModel, StudentModelStore studentModelStore)
        {
            _recordsListingItemViewModel = recordsListingItemViewModel;
            _studentModelStore = studentModelStore;
        }
        #endregion

        #region AsyncCommandBase
        public override async Task ExecuteAsync(object? parameter)
        {
            StudentModel studentModel = _recordsListingItemViewModel.StudentModel;

            try
            {
                await _studentModelStore.Delete(studentModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
