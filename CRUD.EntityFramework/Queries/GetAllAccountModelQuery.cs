using CRUD.Domain.Models;
using CRUD.Domain.Queries;
using CRUD.EntityFramework.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CRUD.EntityFramework.Queries
{
    public class GetAllAccountModelQuery : IGetAllQuery<AccountModel>
    {
        #region Fields
        private readonly ClassManagementSystemDbContextFactory _classManagementSystemDbContextFactory;
        #endregion

        #region Constructor
        public GetAllAccountModelQuery(ClassManagementSystemDbContextFactory classManagementSystemDbContextFactory)
        {
            _classManagementSystemDbContextFactory = classManagementSystemDbContextFactory;
        }
        #endregion

        #region IGetAllAccountModelQuery
        public async Task<IEnumerable<AccountModel>> Execute()
        {
            using (ClassManagementSystemDbContext context = _classManagementSystemDbContextFactory.Create())
            {
                IEnumerable<AccountModelDto> accountModelDtos = await context.AccountModel.ToListAsync();

                return accountModelDtos.Select(accountModel => new AccountModel(
                    accountModel.Id,
                    accountModel.Username,
                    accountModel.Password,
                    accountModel.FirstName,
                    accountModel.LastName));
            }
        }
        #endregion
    }
}
