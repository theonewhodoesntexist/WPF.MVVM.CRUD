using CRUD.WPF.ViewModels;
using System;

namespace CRUD.WPF.Stores
{
    public class ModalNavigationStore
    {
		#region Properties
		private ViewModelBase _currentModalViewModel;
		public ViewModelBase CurrentModalViewModel
		{
			get
			{
				return _currentModalViewModel;
			}
			set
			{
                _currentModalViewModel?.Dispose();
                _currentModalViewModel = value;
				CurrentModalViewModelChanged?.Invoke();
            }
		}

        public bool IsOpen => CurrentModalViewModel != null;
        #endregion

        #region Helper methods
        public void Close()
        {
            CurrentModalViewModel = null;
        }
        #endregion

        #region Events
        public event Action CurrentModalViewModelChanged;
        #endregion
    }
}
