﻿using CRUD.Domain.Models;
using CRUD.WPF.Commands;
using CRUD.WPF.Commands.Records;
using CRUD.WPF.Services;
using CRUD.WPF.Stores.Accounts;
using CRUD.WPF.Stores.Records;
using System.Windows.Input;

namespace CRUD.WPF.ViewModels.Records
{
    public class RecordsListingItemViewModel : ViewModelBase
    {
        #region Fields
        private readonly StudentModelStore _studentModelStore;
        private readonly NavigationManager _navigationManager;
        private readonly AccountStore _accountStore;
        #endregion

        #region Properties
        public StudentModel StudentModel { get; private set; }
        public string FullName => $"{FirstName} {LastName}";
        public string FirstName => StudentModel.FirstName;
        public string LastName => StudentModel.LastName;
        public bool IsOutstanding => StudentModel.IsOutstanding;
        public ICommand OutstandingCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        public bool IsLoggedIn => _accountStore.IsLoggedIn;

        private bool _hasClicked;
        public bool HasClicked
        {
            get
            {
                return _hasClicked;
            }
            set
            {
                _hasClicked = value;
                OnPropertyChanged(nameof(HasClicked));
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);
        #endregion

        #region Constructor
        public RecordsListingItemViewModel(
            StudentModel studentModel,
            StudentModelStore studentModelStore, 
            NavigationManager navigationManager,
            AccountStore accountStore)
        {
            StudentModel = studentModel;
            _studentModelStore = studentModelStore;
            _navigationManager = navigationManager;
            _accountStore = accountStore;

            UpdateCommand = new NavigateCommand(_navigationManager.CreateModalNavigationService(
                () => new UpdateRecordsViewModel(
                    this,
                    _studentModelStore, 
                    _navigationManager)));
            DeleteCommand = new DeleteRecordsCommand(this, _studentModelStore);
            OutstandingCommand = new OutstandingStudentCommand(_studentModelStore, this);

            _accountStore.CurrentAccountChanged += AccountStore_CurrentAccountChanged;
        }
        #endregion

        #region Subscribers
        private void AccountStore_CurrentAccountChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
        }
        #endregion

        #region Helper methods
        public void Update(StudentModel studentModel)
        {
            StudentModel = studentModel;

            OnPropertyChanged(nameof(FullName));
            OnPropertyChanged(nameof(FirstName));
            OnPropertyChanged(nameof(LastName));
            OnPropertyChanged(nameof(IsOutstanding));
        }
        #endregion

        #region Dispose
        public override void Dispose()
        {
            _accountStore.CurrentAccountChanged -= AccountStore_CurrentAccountChanged;

            base.Dispose();
        }
        #endregion
    }
}
