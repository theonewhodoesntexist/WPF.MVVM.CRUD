using System.Windows.Input;

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
				OnPropertyChanged(nameof(CanSubmit));
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
				OnPropertyChanged(nameof(CanSubmit));
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
				OnPropertyChanged(nameof(CanSubmit));
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
                _isFemaleChecked = value;
                OnPropertyChanged(nameof(IsFemaleChecked));
            }
        }

        public string Sex
        {
            get
            {
                if (IsMaleChecked)
                {
                    return "Male";
                }
                else if (IsFemaleChecked)
                {
                    return "Female";
                }
                else
                {
                    return "None";
                }
            }
        }

		private bool _isSubmitting;
		public bool IsSubmitting
		{
			get
			{
				return _isSubmitting;
			}
			set
			{
				_isSubmitting = value;
				OnPropertyChanged(nameof(IsSubmitting));
			}
		}

		public bool CanSubmit => !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName) && !(Age < 0);
		public ICommand SubmitCommand { get; }
		public ICommand CloseCommand { get; }
        #endregion

        #region Constructor
        public RecordsDetailsFormViewModel(ICommand submitCommand, ICommand closeCommand)
        {
            SubmitCommand = submitCommand;
            CloseCommand = closeCommand;
        }
        #endregion
    }
}
