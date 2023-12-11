using CRUD.WPF.Stores.Records;
using CRUD.WPF.ViewModels.Records;
using CRUD.WPF.Views.Records;
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
            Guid id = _recordsListingItemViewModel.StudentModel.Id;

            _recordsListingItemViewModel.HasClicked = true;

            try
            {
                await _studentModelStore.Delete(id);
            }
            catch (Exception)
            {
                _recordsListingItemViewModel.ErrorMessage = "Failed to delete a record!";
                await Task.Delay(3000);
                _recordsListingItemViewModel.ErrorMessage = null;
            }
            finally
            {
                _recordsListingItemViewModel.HasClicked = false;
            }
        }
        #endregion
    }
}
