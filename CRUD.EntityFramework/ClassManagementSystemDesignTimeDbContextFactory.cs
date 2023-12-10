using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CRUD.EntityFramework
{
    public class ClassManagementSystemDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ClassManagementSystemDbContext>
    {
        public ClassManagementSystemDbContext CreateDbContext(string[] args = null)
        {
            return new ClassManagementSystemDbContext(
                new DbContextOptionsBuilder()
                .UseSqlite("Data Source=ClassManagementSystem.db")
                .Options);
        }
    }
}
