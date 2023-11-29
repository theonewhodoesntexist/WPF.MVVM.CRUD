using CRUD.Domain.Models;

namespace CRUD.Domain.Commands
{
    public interface IUpdateStudentModelCommand
    {
        Task Execute(StudentModel studentModel);
    }
}
