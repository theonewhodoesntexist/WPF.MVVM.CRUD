using CRUD.WPF.Stores.Records;
using CRUD.WPF.ViewModels.Records;
using System;
using System.Threading.Tasks;

namespace CRUD.WPF.Commands.Records
{
    public class LoadRecordsCommand : AsyncCommandBase
    {
        #region Fields
        private readonly StudentModelStore _studentModelStore;
        private readonly RecordsViewModel _recordsViewModel;
        #endregion

        #region Constructor
        public LoadRecordsCommand(StudentModelStore studentModelStore, RecordsViewModel recordsViewModel)
        {
            _studentModelStore = studentModelStore;
            _recordsViewModel = recordsViewModel;
        }
        #endregion

        #region AsyncCommandBase
        public async override Task ExecuteAsync(object? parameter)
        {
            _recordsViewModel.IsLoading = true;

            try
            {
                await _studentModelStore.Load();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _recordsViewModel.IsLoading = false;
            }
        }
        #endregion
    }
}
