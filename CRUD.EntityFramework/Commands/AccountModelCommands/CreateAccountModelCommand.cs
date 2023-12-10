using CRUD.Domain.Commands;
using CRUD.Domain.Models;
using CRUD.EntityFramework.DTOs;

namespace CRUD.EntityFramework.Commands.AccountModelCommands
{
    public class CreateAccountModelCommand : ICreateCommand<AccountModel>
    {
        #region Fields
        private readonly ClassManagementSystemDbContextFactory _classManagementSystemDbContextFactory;
        #endregion

        #region Constructor
        public CreateAccountModelCommand(ClassManagementSystemDbContextFactory classManagementSystemDbContextFactory)
        {
            _classManagementSystemDbContextFactory = classManagementSystemDbContextFactory;
        }
        #endregion

        #region ICreateAccountModelCommand
        public async Task Execute(AccountModel model)
        {
            using (ClassManagementSystemDbContext context = _classManagementSystemDbContextFactory.Create())
            {
                AccountModelDto accountModelDto = new AccountModelDto()
                {
                    Id = model.Id,
                    Username = model.Username,
                    Password = model.Password,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };

                context.AccountModel.Add(accountModelDto);
                await context.SaveChangesAsync();
            }
        }
        #endregion
    }
}
