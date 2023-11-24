using CRUD.WPF.Stores.Dashboard;

namespace CRUD.WPF.ViewModels.Dashboard
{
    public class MaleStudentsViewModel : ViewModelBase
    {
        #region Fields
        private readonly DashboardStudentsStores _dashboardStudentsStores;
        #endregion

        #region Properties
        public int MaleStudents => _dashboardStudentsStores.MaleStudents;
        #endregion

        #region Constructor
        public MaleStudentsViewModel(DashboardStudentsStores dashboardStudentsStores)
        {
            _dashboardStudentsStores = dashboardStudentsStores;

            _dashboardStudentsStores.MaleStudentsChanged += DashboardStudentsStores_MaleStudentsChanged;
        }
        #endregion

        #region Subscribers
        private void DashboardStudentsStores_MaleStudentsChanged()
        {
            OnPropertyChanged(nameof(MaleStudents));
        }
        #endregion

        #region Dispose
        public override void Dispose()
        {
            _dashboardStudentsStores.MaleStudentsChanged += DashboardStudentsStores_MaleStudentsChanged;

            base.Dispose();
        }
        #endregion
    }
}
