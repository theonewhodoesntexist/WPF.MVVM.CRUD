using CRUD.Domain.Models;

namespace CRUD.Domain.Queries
{
    public interface IGetAllQuery<TModel>
        where TModel : IModel
    {
        Task<IEnumerable<TModel>> Execute();
    }
}
