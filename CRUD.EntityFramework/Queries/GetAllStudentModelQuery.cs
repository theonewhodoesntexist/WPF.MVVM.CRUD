using CRUD.Domain.Models;
using CRUD.Domain.Queries;
using CRUD.EntityFramework.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CRUD.EntityFramework.Queries
{
    public class GetAllStudentModelQuery : IGetAllStudentModelQuery
    {
        #region Fields
        private readonly StudentModelDbContextFactory _studentModelDbContextFactory;
        #endregion

        #region Constructor
        public GetAllStudentModelQuery(StudentModelDbContextFactory studentModelDbContextFactory)
        {
            _studentModelDbContextFactory = studentModelDbContextFactory;
        }
        #endregion

        #region IGetAllStudentModelQuery
        public async Task<IEnumerable<StudentModel>> Execute()
        {
            using (StudentModelDbContext context = _studentModelDbContextFactory.Create())
            {
                IEnumerable<StudentModelDto> studentModelDtos = await context.StudentModel.ToListAsync();

                return studentModelDtos.Select(studentModel => new StudentModel(
                    studentModel.Id, 
                    studentModel.FirstName,
                    studentModel.LastName,
                    studentModel.Age, 
                    studentModel.Sex,
                    studentModel.IsOutstanding));
            }
        }
        #endregion
    }
}
