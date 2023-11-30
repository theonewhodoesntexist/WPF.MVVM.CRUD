using CRUD.Domain.Commands;
using CRUD.Domain.Models;
using CRUD.EntityFramework.DTOs;

namespace CRUD.EntityFramework.Commands
{
    public class DeleteStudentModelCommand : IDeleteStudentModelCommand
    {
        #region Fields
        private readonly StudentModelDbContextFactory _studentModelDbContextFactory;
        #endregion

        #region Constructor
        public DeleteStudentModelCommand(StudentModelDbContextFactory studentModelDbContextFactory)
        {
            _studentModelDbContextFactory = studentModelDbContextFactory;
        }
        #endregion

        #region IDeleteStudentModelCommand
        public async Task Execute(Guid id)
        {
            using (StudentModelDbContext context = _studentModelDbContextFactory.Create())
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
