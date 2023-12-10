using CRUD.Domain.Models;
using CRUD.Domain.Queries;
using CRUD.EntityFramework.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CRUD.EntityFramework.Queries
{
    public class GetAllStudentModelQuery : IGetAllQuery<StudentModel>
    {
        #region Fields
        private readonly ClassManagementSystemDbContextFactory _classManagementSystemDbContextFactory;
        #endregion

        #region Constructor
        public GetAllStudentModelQuery(ClassManagementSystemDbContextFactory classManagementSystemDbContextFactory)
        {
            _classManagementSystemDbContextFactory = classManagementSystemDbContextFactory;
        }
        #endregion

        #region IGetAllStudentModelQuery
        public async Task<IEnumerable<StudentModel>> Execute()
        {
            using (ClassManagementSystemDbContext context = _classManagementSystemDbContextFactory.Create())
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
