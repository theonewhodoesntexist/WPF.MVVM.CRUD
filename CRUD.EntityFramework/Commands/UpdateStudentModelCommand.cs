using CRUD.Domain.Commands;
using CRUD.Domain.Models;
using CRUD.EntityFramework.DTOs;

namespace CRUD.EntityFramework.Commands
{
    public class UpdateStudentModelCommand : IUpdateStudentModelCommand
    {
        #region Fields
        private readonly StudentModelDbContextFactory _studentModelDbContextFactory;
        #endregion

        #region Constructor
        public UpdateStudentModelCommand(StudentModelDbContextFactory studentModelDbContextFactory)
        {
            _studentModelDbContextFactory = studentModelDbContextFactory;
        }
        #endregion

        #region IUpdateStudentModelCommand
        public async Task Execute(StudentModel studentModel)
        {
            using (StudentModelDbContext context = _studentModelDbContextFactory.Create())
            {
                StudentModelDto studentModelDto = new StudentModelDto()
                {
                    Id = studentModel.Id,
                    FirstName = studentModel.FirstName,
                    LastName = studentModel.LastName,
                    Age = studentModel.Age,
                    Sex = studentModel.Sex,
                    IsOutstanding = studentModel.IsOutstanding
                };

                context.StudentModel.Update(studentModelDto);
                await context.SaveChangesAsync();
            }
        }
        #endregion
    }
}
