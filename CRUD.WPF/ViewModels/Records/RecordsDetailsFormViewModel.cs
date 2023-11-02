﻿using System.Windows.Input;

namespace CRUD.WPF.ViewModels.Records
{
    public class RecordsDetailsFormViewModel : ViewModelBase
    {
		#region Properties
		private string _firstName;
		public string FirstName
		{
			get
			{
				return _firstName;
			}
			set
			{
				_firstName = value;
				OnPropertyChanged(nameof(FirstName));
			}
		}

		private string _lastName;
		public string LastName
		{
			get
			{
				return _lastName;
			}
			set
			{
				_lastName = value;
				OnPropertyChanged(nameof(LastName));
			}
		}

		private int _age;
		public int Age
		{
			get
			{
				return _age;
			}
			set
			{
				_age = value;
				OnPropertyChanged(nameof(Age));
			}
		}

		private bool _isMaleChecked;
		public bool IsMaleChecked
		{
			get
			{
				return _isMaleChecked;
			}
			set
			{
				_isMaleChecked = value;
				OnPropertyChanged(nameof(IsMaleChecked));
			}
		}

        private bool _isFemaleChecked;
        public bool IsFemaleChecked
        {
            get
            {
                return _isFemaleChecked;
            }
            set
            {
                _isMaleChecked = value;
                OnPropertyChanged(nameof(_isFemaleChecked));
            }
        }

        public bool CanSubmit => !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName) && !(Age < 0);
		public ICommand SubmitCommand { get; }
		public ICommand CancelCommand { get; }
        #endregion
    }
}