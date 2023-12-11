using CRUD.Domain.Models;
using CRUD.WPF.Services;
using CRUD.WPF.Stores.Records;
using CRUD.WPF.ViewModels.Records;
using System;
using System.Threading.Tasks;

namespace CRUD.WPF.Commands.Records
{
    public class CreateRecordsCommand : AsyncCommandBase
    {
        #region Fields
        private readonly StudentModelStore _studentModelStore;
        private readonly INavigationService _closeModalNavigationService;
        private readonly CreateRecordsViewModel _createRecordsViewModel;
        #endregion

        #region Constructor
        public CreateRecordsCommand(
            StudentModelStore studentModelStore, 
            INavigationService closeModalNavigationService, 
            CreateRecordsViewModel createRecordsViewModel)
        {
            _studentModelStore = studentModelStore;
            _closeModalNavigationService = closeModalNavigationService;
            _createRecordsViewModel = createRecordsViewModel;
        }
        #endregion

        #region AsyncCommandBase
        public override async Task ExecuteAsync(object? parameter)
        {
            RecordsDetailsFormViewModel recordsDetailsFormViewModel = _createRecordsViewModel.RecordsDetailsFormViewModel;

            recordsDetailsFormViewModel.IsSubmitting = true;

            StudentModel studentModel = new StudentModel(
                Guid.NewGuid(),
                recordsDetailsFormViewModel.FirstName,
                recordsDetailsFormViewModel.LastName,
                recordsDetailsFormViewModel.Age, 
                recordsDetailsFormViewModel.Sex, 
                false);

            try
            {
                await _studentModelStore.Create(studentModel);

                _closeModalNavigationService.Navigate();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                recordsDetailsFormViewModel.IsSubmitting = false;
            }
        }
        #endregion
    }
}
