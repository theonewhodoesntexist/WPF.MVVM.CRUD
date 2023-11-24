using CRUD.WPF.Stores.Dashboard;

namespace CRUD.WPF.ViewModels.Dashboard
{
    public class TotalStudentsViewModel : ViewModelBase
    {
        #region Fields
        private readonly DashboardStudentsStores _dashboardStudentsStores;
        #endregion

        #region Properties
        public int TotalStudents => _dashboardStudentsStores.TotalStudents;
        #endregion

        #region Constructor
        public TotalStudentsViewModel(DashboardStudentsStores dashboardStudentsStores)
        {
            _dashboardStudentsStores = dashboardStudentsStores;

            _dashboardStudentsStores.TotalStudentsChanged += DashboardStudentsStores_TotalStudentsChanged;
        }
        #endregion

        #region Subscribers
        private void DashboardStudentsStores_TotalStudentsChanged()
        {
            OnPropertyChanged(nameof(TotalStudents));
        }
        #endregion

        #region Dispose
        public override void Dispose()
        {
            _dashboardStudentsStores.TotalStudentsChanged -= DashboardStudentsStores_TotalStudentsChanged;

            base.Dispose();
        }
        #endregion
    }
}
