using Microsoft.EntityFrameworkCore;

namespace CRUD.EntityFramework
{
    public class StudentModelDbContextFactory
    {
        #region Fields
        private readonly DbContextOptions _options;
        #endregion

        #region Constructor
        public StudentModelDbContextFactory(DbContextOptions options)
        {
            _options = options;
        }
        #endregion

        #region Helper methods
        public StudentModelDbContext Create()
        {
            return new StudentModelDbContext(_options);
        }
        #endregion
    }
}
