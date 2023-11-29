namespace CRUD.Domain.Commands
{
    public interface IDeleteStudentModelCommand
    {
        Task Execute(Guid id);
    }
}
