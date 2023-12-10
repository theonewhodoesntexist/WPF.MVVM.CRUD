using CRUD.Domain.Commands;
using CRUD.Domain.Models;
using CRUD.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.WPF.Stores.Records
{
    public class StudentModelStore
    {
        #region Fields
        private readonly IGetAllQuery<StudentModel> _getAllStudentModelQuery;
        private readonly ICreateCommand<StudentModel> _createStudentModelCommand;
        private readonly IUpdateCommand<StudentModel> _updateStudentModelCommand;
        private readonly IDeleteCommand<Guid> _deleteStudentModelCommand;
        private readonly ObservableCollection<StudentModel> _studentModels;
        #endregion

        #region Properties
        public IEnumerable<StudentModel> StudentModel => _studentModels;
        #endregion

        #region Constructor
        public StudentModelStore(
            IGetAllQuery<StudentModel> getAllStudentModelQuery,
            ICreateCommand<StudentModel> createStudentModelCommand,
            IUpdateCommand<StudentModel> updateStudentModelCommand,
            IDeleteCommand<Guid> deleteStudentModelCommand)
        {
            _getAllStudentModelQuery = getAllStudentModelQuery;
            _createStudentModelCommand = createStudentModelCommand;
            _updateStudentModelCommand = updateStudentModelCommand;
            _deleteStudentModelCommand = deleteStudentModelCommand;
            _studentModels = new ObservableCollection<StudentModel>();
        }
        #endregion

        #region Events
        public event Action<StudentModel> StudentModelCreated;
        public event Action<StudentModel> StudentModelUpdated;
        public event Action<Guid> StudentModelDeleted;
        public event Action StudentModelLoaded;
        #endregion

        #region Helper methods
        public async Task Load()
        {
            IEnumerable<StudentModel> studentModels = await _getAllStudentModelQuery.Execute();

            _studentModels.Clear();

            foreach (StudentModel studentModel in studentModels)
            {
                _studentModels.Add(studentModel);
            }

            StudentModelLoaded?.Invoke();
        }

        public async Task Create(StudentModel studentModel)
        {
            await _createStudentModelCommand.Execute(studentModel);

            _studentModels.Add(studentModel);

            StudentModelCreated?.Invoke(studentModel);
        }

        public async Task Update(StudentModel studentModel)
        {
            await _updateStudentModelCommand.Execute(studentModel);

            int currentIndex = _studentModels.IndexOf(_studentModels.FirstOrDefault(student => student.Id == studentModel.Id));
            if (currentIndex != -1) 
            {
                _studentModels[currentIndex] = studentModel;
            }
            else
            {
                _studentModels.Add(studentModel);
            }

            StudentModelUpdated?.Invoke(studentModel);
        }

        public async Task Delete(Guid id)
        {
            await _deleteStudentModelCommand.Execute(id);

            StudentModel studentToRemove = _studentModels.FirstOrDefault(student => student.Id == id);
            if (studentToRemove != null)
            {
                _studentModels.Remove(studentToRemove);
            }

            StudentModelDeleted?.Invoke(id);
        }
        #endregion
    }
}
