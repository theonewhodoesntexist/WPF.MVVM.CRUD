using CRUD.WPF.Stores;

namespace CRUD.WPF.Services
{
    public class CloseModalNavigationService : INavigationService
    {
        #region Fields
        private readonly ModalNavigationStore _modalNavigationStore;
        #endregion

        #region Constructor
        public CloseModalNavigationService(ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
        }
        #endregion

        #region INavigationService
        public void Navigate()
        {
            _modalNavigationStore.Close();
        }
        #endregion
    }
}
