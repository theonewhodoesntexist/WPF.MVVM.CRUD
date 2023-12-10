using CRUD.Domain.Commands;
using CRUD.Domain.Models;
using CRUD.EntityFramework.DTOs;

namespace CRUD.EntityFramework.Commands.StudentModelCommands
{
    public class CreateStudentModelCommand : ICreateCommand<StudentModel>
    {
        #region Fields
        private readonly ClassManagementSystemDbContextFactory _classManagementSystemDbContextFactory;
        #endregion

        #region Constructor
        public CreateStudentModelCommand(ClassManagementSystemDbContextFactory classManagementSystemDbContextFactory)
        {
            _classManagementSystemDbContextFactory = classManagementSystemDbContextFactory;
        }
        #endregion

        #region ICreateStudentModelCommand
        public async Task Execute(StudentModel model)
        {
            using (ClassManagementSystemDbContext context = _classManagementSystemDbContextFactory.Create())
            {
                StudentModelDto studentModelDto = new StudentModelDto()
                {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Age = model.Age,
                    Sex = model.Sex,
                    IsOutstanding = model.IsOutstanding
                };

                context.StudentModel.Add(studentModelDto);
                await context.SaveChangesAsync();
            }
        }
        #endregion
    }
}
