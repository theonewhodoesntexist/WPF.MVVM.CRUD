using CRUD.WPF.Models;
using CRUD.WPF.Stores.Records;

namespace CRUD.WPF.ViewModels.Records
{
    public class RecordsDetailsViewModel : ViewModelBase
    {
        #region Fields
        private readonly SelectedStudentModelStore _selectedStudentModelStore;
        #endregion

        #region Properties
        public StudentModel SelectedStudentModel => _selectedStudentModelStore.SelectedStudentModel;
        public string FirstName => SelectedStudentModel?.FirstName ?? "None";
        public string LastName => SelectedStudentModel?.LastName ?? "None";
        public string Age
        {
            get
            {
                int? age = SelectedStudentModel?.Age;
                if (age.HasValue && age.Value == 0)
                {
                    return "None";
                }
                return age.HasValue ? age.ToString() : "None";
            }
        }
        public string Sex => SelectedStudentModel?.Sex ?? "None";
        #endregion

        #region Constructor
        public RecordsDetailsViewModel(SelectedStudentModelStore selectedStudentModelStore)
        {
            _selectedStudentModelStore = selectedStudentModelStore;

            _selectedStudentModelStore.SelectedStudentModelChanged += SelectedStudentModelStore_SelectedStudentModelChanged;
        }
        #endregion

        #region Subscribers
        private void SelectedStudentModelStore_SelectedStudentModelChanged()
        {
            OnPropertyChanged(nameof(FirstName));
            OnPropertyChanged(nameof(LastName));
            OnPropertyChanged(nameof(Age));
            OnPropertyChanged(nameof(Sex));
        }
        #endregion

        #region Dispose
        public override void Dispose()
        {
            _selectedStudentModelStore.SelectedStudentModelChanged -= SelectedStudentModelStore_SelectedStudentModelChanged;

            base.Dispose();
        }
        #endregion
    }
}
