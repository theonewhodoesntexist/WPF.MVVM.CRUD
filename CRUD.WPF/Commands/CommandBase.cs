﻿using System;
using System.Windows.Input;

namespace CRUD.WPF.Commands
{
    public abstract class CommandBase : ICommand
    {
        #region ICommand
        public event EventHandler? CanExecuteChanged;

        public virtual bool CanExecute(object? parameter)
        {
            return true;
        }

        public abstract void Execute(object? parameter);
        #endregion

        #region Helper methods
        protected void OnCanExecuteChanged ()
        {
            CanExecuteChanged?.Invoke (this, new EventArgs ());
        }
        #endregion
    }
}
