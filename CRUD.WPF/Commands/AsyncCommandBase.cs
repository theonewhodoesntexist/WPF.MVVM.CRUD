using System;
using System.Threading.Tasks;

namespace CRUD.WPF.Commands
{
    public abstract class AsyncCommandBase : CommandBase
    {
        #region CommandBase
        public override async void Execute(object? parameter)
        {
            try
            {
                await ExecuteAsync(parameter);
            }
            catch (Exception) { }
        }
        #endregion

        #region Helper methods
        public abstract Task ExecuteAsync(object? parameter);
        #endregion
    }
}
