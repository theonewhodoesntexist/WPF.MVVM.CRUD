using CRUD.WPF.Commands;
using CRUD.WPF.Commands.Records;
using CRUD.Domain.Models;
using CRUD.WPF.Services;
using CRUD.WPF.Stores.Records;
using System;
using System.Windows.Input;

namespace CRUD.WPF.ViewModels.Records
{
    public class UpdateRecordsViewModel : ViewModelBase
    {
        #region Properties
        public RecordsDetailsFormViewModel RecordsDetailsFormViewModel { get; }
        public Guid StudentModelId { get; }
        public bool StudentModelIsOutstanding { get; }
        public bool StudentModelIsMaleChecked { get; }
        public bool StudentModelIsFemaleChecked { get; }
        #endregion

        #region Contructor
        public UpdateRecordsViewModel(
            RecordsListingItemViewModel recordsListingItemViewModel, 
            StudentModelStore studentModelStore, 
            NavigationManager navigationManager)
        {
            StudentModel studentModel = recordsListingItemViewModel.StudentModel;
            StudentModelId = studentModel.Id;
            StudentModelIsOutstanding = studentModel.IsOutstanding;

            ICommand submitCommand = new UpdateRecordsCommand(
                studentModelStore, 
                navigationManager.CreateCloseModalNavigationService(),
                this);
            ICommand cancelCommand = new CloseModalCommand(navigationManager.CreateCloseModalNavigationService());

            if (studentModel.Sex == "Male")
            {
                StudentModelIsMaleChecked = true;
                StudentModelIsFemaleChecked = false;
            }
            else if (studentModel.Sex == "Female")
            {
                StudentModelIsMaleChecked = false;
                StudentModelIsFemaleChecked = true;
            }
            else
            {
                StudentModelIsMaleChecked = false;
                StudentModelIsFemaleChecked = false;
            }

            RecordsDetailsFormViewModel = new RecordsDetailsFormViewModel(submitCommand, cancelCommand)
            {
                FirstName = studentModel.FirstName,
                LastName = studentModel.LastName,
                Age = studentModel.Age,
                IsMaleChecked = StudentModelIsMaleChecked,
                IsFemaleChecked = StudentModelIsFemaleChecked
            };
        }
        #endregion
    }
}
