using CRUD.WPF.ViewModels.Records;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CRUD.WPF.ViewModels.Dashboard
{
    public class OutstandingStudentsViewModel : ViewModelBase
    {
        #region Fields
        private readonly ObservableCollection<RecordsListingItemViewModel> _outstandingStudents = RecordsStorage.RecordsCollection;
        #endregion

        #region Properties
        public IEnumerable<RecordsListingItemViewModel> OutstandingStudents => _outstandingStudents?.Where(student => student.IsOutstanding);
        #endregion
    }
}
