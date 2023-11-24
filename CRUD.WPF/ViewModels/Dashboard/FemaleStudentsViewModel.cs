using CRUD.WPF.Stores.Dashboard;

namespace CRUD.WPF.ViewModels.Dashboard
{
    public class FemaleStudentsViewModel : ViewModelBase
    {
        #region Fields
        private readonly DashboardStudentsStores _dashboardStudentsStores;
        #endregion

        #region Properties
        public int FemaleStudents => _dashboardStudentsStores.FemaleStudents;
        #endregion

        #region Constructor
        public FemaleStudentsViewModel(DashboardStudentsStores dashboardStudentsStores)
        {
            _dashboardStudentsStores = dashboardStudentsStores;

            _dashboardStudentsStores.FemaleStudentsChanged += DashboardStudentsStores_FemaleStudentsChanged;
        }
        #endregion

        #region Subscribers
        private void DashboardStudentsStores_FemaleStudentsChanged()
        {
            OnPropertyChanged(nameof(FemaleStudents));
        }
        #endregion

        #region Dispose
        public override void Dispose()
        {
            _dashboardStudentsStores.FemaleStudentsChanged -= DashboardStudentsStores_FemaleStudentsChanged;

            base.Dispose();
        }
        #endregion
    }
}
