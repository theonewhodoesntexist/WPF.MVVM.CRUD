using CRUD.EntityFramework.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CRUD.EntityFramework
{
    public class ClassManagementSystemDbContext : DbContext
    {
        #region Properties
        public DbSet<StudentModelDto> StudentModel { get; set; }
        public DbSet<AccountModelDto> AccountModel { get; set; }
        #endregion

        #region Constructor
        public ClassManagementSystemDbContext(DbContextOptions options) : base(options)
        {
        }
        #endregion
    }
}
