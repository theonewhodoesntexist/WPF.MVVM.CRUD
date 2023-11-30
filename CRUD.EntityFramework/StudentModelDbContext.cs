using CRUD.EntityFramework.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CRUD.EntityFramework
{
    public class StudentModelDbContext : DbContext
    {
        #region Properties
        public DbSet<StudentModelDto> StudentModel { get; set; }
        #endregion

        #region Constructor
        public StudentModelDbContext(DbContextOptions options) : base(options)
        {
        }
        #endregion
    }
}
