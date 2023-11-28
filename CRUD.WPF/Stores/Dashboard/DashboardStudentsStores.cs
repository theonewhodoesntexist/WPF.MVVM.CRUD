using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUD.WPF.Stores.Dashboard
{
    public class DashboardStudentsStores
    {
        #region Properties
        private int _totalStudents;
        public int TotalStudents
        {
            get
            {
                return _totalStudents;
            }
            set
            {
                _totalStudents = value;
                TotalStudentsChanged?.Invoke();
            }
        }

        private int _maleStudents;
        public int MaleStudents
        {
            get
            {
                return _maleStudents;
            }
            set
            {
                _maleStudents = value;
                MaleStudentsChanged?.Invoke();
            }
        }

        private int _femaleStudents;
        public int FemaleStudents
        {
            get
            {
                return _femaleStudents;
            }
            set
            {
                _femaleStudents = value;
                FemaleStudentsChanged?.Invoke();
            }
        }

        private string _oldestStudentName;
        public string OldestStudentName
        {
            get
            {
                return _oldestStudentName;
            }
            set
            {
                _oldestStudentName = value;
                OldestStudentNameChanged?.Invoke();
            }
        }

        private int _oldestStudentAge;
        public int OldestStudentAge
        {
            get
            {
                return _oldestStudentAge;
            }
            set
            {
                _oldestStudentAge = value;
                OldestStudentAgeChanged?.Invoke();
            }
        }

        private string _youngestStudentName;
        public string YoungestStudentName
        {
            get
            {
                return _youngestStudentName;
            }
            set
            {
                _youngestStudentName = value;
                YoungestStudentNameChanged?.Invoke();
            }
        }

        private int _youngestStudentAge;
        public int YoungestStudentAge
        {
            get
            {
                return _youngestStudentAge;
            }
            set
            {
                _youngestStudentAge = value;
                YoungestStudentAgeChanged?.Invoke();
            }
        }
        #endregion

        #region Events
        public event Action TotalStudentsChanged;
        public event Action MaleStudentsChanged;
        public event Action FemaleStudentsChanged;
        public event Action OldestStudentNameChanged;
        public event Action OldestStudentAgeChanged;
        public event Action YoungestStudentNameChanged;
        public event Action YoungestStudentAgeChanged;
        #endregion
    }
}
