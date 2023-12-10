using CRUD.Domain.Commands;
using CRUD.EntityFramework.DTOs;

namespace CRUD.EntityFramework.Commands.StudentModelCommands
{
    public class DeleteStudentModelCommand : IDeleteCommand<Guid>
    {
        #region Fields
        private readonly ClassManagementSystemDbContextFactory _classManagementSystemDbContextFactory;
        #endregion

        #region Constructor
        public DeleteStudentModelCommand(ClassManagementSystemDbContextFactory classManagementSystemDbContextFactory)
        {
            _classManagementSystemDbContextFactory = classManagementSystemDbContextFactory;
        }
        #endregion

        #region IDeleteStudentModelCommand
        public async Task Execute(Guid id)
        {
            using (ClassManagementSystemDbContext context = _classManagementSystemDbContextFactory.Create())
            {
                StudentModelDto studentModelDto = new StudentModelDto()
                {
                    Id = id
                };

                context.StudentModel.Remove(studentModelDto);
                await context.SaveChangesAsync();
            }
        }
        #endregion
    }
}
