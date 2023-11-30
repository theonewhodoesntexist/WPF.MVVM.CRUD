using CRUD.Domain.Commands;
using CRUD.Domain.Models;
using CRUD.EntityFramework.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CRUD.EntityFramework.Commands
{
    public class CreateStudentModelCommand : ICreateStudentModelCommand
    {
        #region Fields
        private readonly StudentModelDbContextFactory _studentModelDbContextFactory;
        #endregion

        #region Constructor
        public CreateStudentModelCommand(StudentModelDbContextFactory studentModelDbContextFactory)
        {
            _studentModelDbContextFactory = studentModelDbContextFactory;
        }
        #endregion

        #region ICreateStudentModelCommand
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

                context.StudentModel.Add(studentModelDto);
                await context.SaveChangesAsync();
            }
        }
        #endregion
    }
}
