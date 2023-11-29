using CRUD.Domain.Models;

namespace CRUD.Domain.Commands
{
    public interface ICreateStudentModelCommand
    {
        Task Execute(StudentModel studentModel);
    }
}
