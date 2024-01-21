using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CRUD.EntityFramework
{
    public class ClassManagementSystemDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ClassManagementSystemDbContext>
    {
        public ClassManagementSystemDbContext CreateDbContext(string[] args = null)
        {
            //return new ClassManagementSystemDbContext(
            //    new DbContextOptionsBuilder()
            //    .UseSqlite("Data Source = ClassManagementSystem.db")
            //    .Options);

            string appDataPath = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string databasePath = Path.Combine(appDataPath, "Class Management System", "ClassManagementSystem.db");

            return new ClassManagementSystemDbContext(
                new DbContextOptionsBuilder<ClassManagementSystemDbContext>()
                    .UseSqlite($"Data Source={databasePath}")
                    .Options);
        }
    }
}
