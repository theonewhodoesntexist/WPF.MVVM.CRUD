using System.Windows.Input;

namespace CRUD.WPF.ViewModels.Account
{
    public class AccountViewModel : ViewModelBase
    {
        #region Properties
        public string Username { get; }
        public string Name { get; }
        public ICommand EditAccountCommand { get; }
        #endregion

        #region Constructor
        public AccountViewModel()
        {
            Username = "moriarity99";
            Name = "Jim Moriarity";
        }
        #endregion
    }
}
