using CRUD.WPF.Stores.Dashboard;

namespace CRUD.WPF.ViewModels.Dashboard
{
    public class YoungestStudentViewModel : ViewModelBase
    {
        #region Fields
        private readonly DashboardStudentsStores _dashboardStudentsStores;
        #endregion

        #region Properties
        public string YoungestStudentName
        {
            get
            {
                int? age = _dashboardStudentsStores.YoungestStudentAge;
                if (age.HasValue && age.Value == 0)
                {
                    return "None";
                }
                return _dashboardStudentsStores.YoungestStudentName;
            }
        }

        public string YoungestStudentAge
        {
            get
            {
                int? age = _dashboardStudentsStores.YoungestStudentAge;
                if (age.HasValue && age.Value == 0)
                {
                    return string.Empty;
                }
                return age.HasValue ? $"{age} years old" : string.Empty;
            }
        }
        #endregion

        #region Constructor
        public YoungestStudentViewModel(DashboardStudentsStores dashboardStudentsStores)
        {
            _dashboardStudentsStores = dashboardStudentsStores;

            _dashboardStudentsStores.YoungestStudentNameChanged += DashboardStudentsStores_YoungestStudentNameChanged;
            _dashboardStudentsStores.YoungestStudentAgeChanged += DashboardStudentsStores_YoungestStudentAgeChanged;
        }
        #endregion

        #region Subscribers
        private void DashboardStudentsStores_YoungestStudentNameChanged()
        {
            OnPropertyChanged(nameof(YoungestStudentName));
        }

        private void DashboardStudentsStores_YoungestStudentAgeChanged()
        {
            OnPropertyChanged(nameof(YoungestStudentAge));
        }
        #endregion

        #region Dispose
        public override void Dispose()
        {
            _dashboardStudentsStores.YoungestStudentNameChanged -= DashboardStudentsStores_YoungestStudentNameChanged;
            _dashboardStudentsStores.YoungestStudentAgeChanged -= DashboardStudentsStores_YoungestStudentAgeChanged;

            base.Dispose();
        }
        #endregion
    }
}
