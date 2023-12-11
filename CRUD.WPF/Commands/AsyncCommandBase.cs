using System;
using System.Threading.Tasks;

namespace CRUD.WPF.Commands
{
    public abstract class AsyncCommandBase : CommandBase
    {
        #region Properties
        private bool _isExecuting;
        public bool IsExecuting
        {
            get
            {
                return _isExecuting;
            }
            set
            {
                _isExecuting = value;
                OnCanExecuteChanged();
            }
        }
        #endregion

        #region CommandBase
        public override bool CanExecute(object? parameter)
        {
            return !IsExecuting &&  base.CanExecute(parameter);
        }

        public override async void Execute(object? parameter)
        {
            IsExecuting = true;
            try
            {
                await ExecuteAsync(parameter);
            }
            catch (Exception) { }
            finally 
            { 
                IsExecuting = false; 
            }
        }
        #endregion

        #region Helper methods
        public abstract Task ExecuteAsync(object? parameter);
        #endregion
    }
}
