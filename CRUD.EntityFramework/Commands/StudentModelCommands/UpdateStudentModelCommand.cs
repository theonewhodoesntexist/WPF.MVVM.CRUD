using CRUD.Domain.Commands;
using CRUD.Domain.Models;
using CRUD.EntityFramework.DTOs;

namespace CRUD.EntityFramework.Commands.StudentModelCommands
{
    public class UpdateStudentModelCommand : IUpdateCommand<StudentModel>
    {
        #region Fields
        private readonly ClassManagementSystemDbContextFactory _classManagementSystemDbContextFactory;
        #endregion

        #region Constructor
        public UpdateStudentModelCommand(ClassManagementSystemDbContextFactory classManagementSystemDbContextFactory)
        {
            _classManagementSystemDbContextFactory = classManagementSystemDbContextFactory;
        }
        #endregion

        #region IUpdateStudentModelCommand
        public async Task Execute(StudentModel studentModel)
        {
            using (ClassManagementSystemDbContext context = _classManagementSystemDbContextFactory.Create())
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
