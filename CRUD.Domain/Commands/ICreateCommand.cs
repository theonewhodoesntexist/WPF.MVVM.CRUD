using CRUD.Domain.Models;

namespace CRUD.Domain.Commands
{
    public interface ICreateCommand<TModel>
        where TModel : IModel
    {
        Task Execute(TModel model);
    }
}
