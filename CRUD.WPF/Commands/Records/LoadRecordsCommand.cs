using CRUD.WPF.Stores.Records;
using System;
using System.Threading.Tasks;

namespace CRUD.WPF.Commands.Records
{
    public class LoadRecordsCommand : AsyncCommandBase
    {
        #region Fields
        private readonly StudentModelStore _studentModelStore;
        #endregion

        #region Constructor
        public LoadRecordsCommand(StudentModelStore studentModelStore)
        {
            _studentModelStore = studentModelStore;
        }
        #endregion

        #region AsyncCommandBase
        public async override Task ExecuteAsync(object? parameter)
        {
            try
            {
                await _studentModelStore.Load();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
