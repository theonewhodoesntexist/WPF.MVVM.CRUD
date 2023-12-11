using CRUD.Domain.Models;
using CRUD.WPF.Services;
using CRUD.WPF.Stores.Records;
using CRUD.WPF.ViewModels.Records;
using System;
using System.Threading.Tasks;

namespace CRUD.WPF.Commands.Records
{
    public class UpdateRecordsCommand : AsyncCommandBase
    {
        #region Fields
        private readonly StudentModelStore _studentModelStore;
        private readonly INavigationService _closeModalNavigationService;
        private readonly UpdateRecordsViewModel _updateRecordsViewModel;
        #endregion

        #region Constructor
        public UpdateRecordsCommand(
            StudentModelStore studentModelStore, 
            INavigationService closeModalNavigationService, 
            UpdateRecordsViewModel updateRecordsViewModel)
        {
            _studentModelStore = studentModelStore;
            _closeModalNavigationService = closeModalNavigationService;
            _updateRecordsViewModel = updateRecordsViewModel;
        }
        #endregion

        #region AsyncCommandBase
        public override async Task ExecuteAsync(object? parameter)
        {
            RecordsDetailsFormViewModel recordsDetailsFormViewModel = _updateRecordsViewModel.RecordsDetailsFormViewModel;

            _updateRecordsViewModel.ErrorMessage = null;
            recordsDetailsFormViewModel.IsSubmitting = true;

            StudentModel studentModel = new StudentModel(
                _updateRecordsViewModel.StudentModelId,
                recordsDetailsFormViewModel.FirstName,
                recordsDetailsFormViewModel.LastName,
                recordsDetailsFormViewModel.Age,
                recordsDetailsFormViewModel.Sex,
                _updateRecordsViewModel.StudentModelIsOutstanding);

            try
            {
                await _studentModelStore.Update(studentModel);

                _closeModalNavigationService.Navigate();
            }
            catch (Exception)
            {
                _updateRecordsViewModel.ErrorMessage = "Failed to update a record! Please try again!";
            }
            finally
            {
                recordsDetailsFormViewModel.IsSubmitting = false;
            }
        }
        #endregion
    }
}
