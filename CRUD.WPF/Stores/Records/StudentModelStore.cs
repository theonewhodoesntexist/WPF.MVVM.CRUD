using CRUD.Domain.Models;
using System;
using System.Threading.Tasks;

namespace CRUD.WPF.Stores.Records
{
    public class StudentModelStore
    {
        #region Events
        public event Action<StudentModel> StudentModelCreated;
        public event Action<StudentModel> StudentModelUpdated;
        public event Action<StudentModel> StudentModelDeleted;
        public event Action<StudentModel> StudentModelOutstanding;
        #endregion

        #region Helper methods
        public async Task Create(StudentModel studentModel)
        {
            StudentModelCreated?.Invoke(studentModel);
        }

        public async Task Update(StudentModel studentModel)
        {
            StudentModelUpdated?.Invoke(studentModel);
        }

        public async Task Delete(StudentModel studentModel)
        {
            StudentModelDeleted?.Invoke(studentModel);
        }

        public async Task Outstanding(StudentModel studentModel)
        {
            StudentModelOutstanding?.Invoke(studentModel);
        }
        #endregion
    }
}
