using CRUD.Domain.Commands;
using CRUD.Domain.Models;
using CRUD.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.WPF.Stores.Accounts
{
    public class AccountModelStore
    {
        #region Fields
        private readonly IGetAllQuery<AccountModel> _getAllAccountModelQuery;
        private readonly ICreateCommand<AccountModel> _createAccountModelCommand;
        private readonly IUpdateCommand<AccountModel> _updateAccountModelCommand;
        private readonly ObservableCollection<AccountModel> _accountModels;
        #endregion

        #region Properties
        public IEnumerable<AccountModel> AccountModel => _accountModels;
        #endregion

        #region Constructor
        public AccountModelStore(
            IGetAllQuery<AccountModel> getAllAccountModelQuery,
            ICreateCommand<AccountModel> createAccountModelCommand,
            IUpdateCommand<AccountModel> updateAccountModelCommand)
        {
            _getAllAccountModelQuery = getAllAccountModelQuery;
            _createAccountModelCommand = createAccountModelCommand;
            _updateAccountModelCommand = updateAccountModelCommand;
            _accountModels = new ObservableCollection<AccountModel>();
        }
        #endregion

        #region Events
        public event Action<AccountModel> AccountModelCreated;
        public event Action<AccountModel> AccountModelUpdated;
        public event Action AccountModelLoaded;
        #endregion

        #region Helper methods
        public async Task Load()
        {
            IEnumerable<AccountModel> accountModels = await _getAllAccountModelQuery.Execute();

            _accountModels.Clear();

            int count = accountModels.Count();

            if (count == 0)
            {
                AccountModel accountModel = new AccountModel(Guid.NewGuid(), "99", "99", "Jim", "Moriarity");
                await Create(accountModel);
            }
            else
            {
                foreach (AccountModel accountModel in accountModels)
                {
                    _accountModels.Add(accountModel);
                }
            }

            AccountModelLoaded?.Invoke();
        }

        public async Task Create(AccountModel accountModel)
        {
            await _createAccountModelCommand.Execute(accountModel);

            _accountModels.Add(accountModel);

            AccountModelCreated?.Invoke(accountModel);
        }
        public async Task Update(AccountModel accountModel)
        {
            await _updateAccountModelCommand.Execute(accountModel);

            int currentIndex = _accountModels.IndexOf(_accountModels.FirstOrDefault(student => student.Id == accountModel.Id));
            if (currentIndex != -1)
            {
                _accountModels[currentIndex] = accountModel;
            }
            else
            {
                _accountModels.Add(accountModel);
            }

            AccountModelUpdated?.Invoke(accountModel);
        }
        #endregion
    }
}
