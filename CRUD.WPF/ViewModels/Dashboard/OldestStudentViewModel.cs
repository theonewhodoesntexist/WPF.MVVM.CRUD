using CRUD.WPF.Stores.Dashboard;

namespace CRUD.WPF.ViewModels.Dashboard
{
    public class OldestStudentViewModel : ViewModelBase
    {
        #region Fields
        private readonly DashboardStudentsStores _dashboardStudentsStores;
        #endregion

        #region Properties
        public string OldestStudentName
        {
            get
            {
                int? age = _dashboardStudentsStores.OldestStudentAge;
                if (age.HasValue && age.Value == 0)
                {
                    return "None";
                }
                return _dashboardStudentsStores.OldestStudentName;
            }
        }

        public string OldestStudentAge
        {
            get
            {
                int? age = _dashboardStudentsStores.OldestStudentAge;
                if (age.HasValue && age.Value == 0)
                {
                    return string.Empty;
                }
                return age.HasValue ? $"{age} years old" : string.Empty;
            }
        }
        #endregion

        #region Constructor
        public OldestStudentViewModel(DashboardStudentsStores dashboardStudentsStores)
        {
            _dashboardStudentsStores = dashboardStudentsStores;

            _dashboardStudentsStores.OldestStudentNameChanged += DashboardStudentsStores_OldestStudentNameChanged;
            _dashboardStudentsStores.OldestStudentAgeChanged += DashboardStudentsStores_OldestStudentAgeChanged;
        }
        #endregion

        #region Subscribers
        private void DashboardStudentsStores_OldestStudentNameChanged()
        {
            OnPropertyChanged(nameof(OldestStudentName));
        }

        private void DashboardStudentsStores_OldestStudentAgeChanged()
        {
            OnPropertyChanged(nameof(OldestStudentAge));
        }
        #endregion

        #region Dispose
        public override void Dispose()
        {
            _dashboardStudentsStores.OldestStudentNameChanged -= DashboardStudentsStores_OldestStudentNameChanged;
            _dashboardStudentsStores.OldestStudentAgeChanged -= DashboardStudentsStores_OldestStudentAgeChanged;
            
            base.Dispose();
        }
        #endregion
    }
}
