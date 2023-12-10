namespace CRUD.Domain.Commands
{
    public interface IDeleteCommand<TGuid>
        where TGuid : struct
    {
        Task Execute(TGuid id);
    }
}
