using CRUD.Domain.Models;

namespace CRUD.Domain.Commands
{
    public interface IUpdateCommand<TModel>
        where TModel : IModel
    {
        Task Execute(TModel model);
    }
}
