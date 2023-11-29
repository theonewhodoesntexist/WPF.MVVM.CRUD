using CRUD.Domain.Models;

namespace CRUD.Domain.Queries
{
    public interface IGetAllStudentModelQuery
    {
        Task<IEnumerable<StudentModel>> Execute();
    }
}
