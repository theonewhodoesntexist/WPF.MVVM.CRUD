using Microsoft.EntityFrameworkCore;

namespace CRUD.EntityFramework
{
    public class ClassManagementSystemDbContextFactory
    {
        #region Fields
        private readonly DbContextOptions _options;
        #endregion

        #region Constructor
        public ClassManagementSystemDbContextFactory(DbContextOptions options)
        {
            _options = options;
        }
        #endregion

        #region Helper methods
        public ClassManagementSystemDbContext Create()
        {
            return new ClassManagementSystemDbContext(_options);
        }
        #endregion
    }
}
