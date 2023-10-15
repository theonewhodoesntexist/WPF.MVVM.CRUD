using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CRUD.WPF.ViewModels.Dashboard
{
    public class OutstandingStudentsViewModel : ViewModelBase
    {
        #region Fields
        private readonly ObservableCollection<string> _outstandingStudents;
        #endregion

        #region Properties
        public IEnumerable<string> OutstandingStudents => _outstandingStudents;
        #endregion

        #region Constructor
        public OutstandingStudentsViewModel()
        {
            _outstandingStudents = new ObservableCollection<string>();

            _outstandingStudents.Add("Johan Liebert");
            _outstandingStudents.Add("Jordan Faciol");
            _outstandingStudents.Add("John Doe");
        }
        #endregion
    }
}
