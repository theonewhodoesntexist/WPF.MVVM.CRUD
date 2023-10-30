using CRUD.WPF.ViewModels;

namespace CRUD.WPF.Services
{
    public interface INavigationService<TViewModel>
        where TViewModel : ViewModelBase
    {
        void Navigate();
    }
}