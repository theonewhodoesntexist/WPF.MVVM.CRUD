using System;

namespace CRUD.WPF.Models
{
    public class StudentModel
    {
        #region Properties
        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public int Age { get; }
        public string Sex { get; }

        private bool _isOutstanding;
        public bool IsOutstanding
        {
            get
            {
                return _isOutstanding;
            }
            set
            {
                _isOutstanding = value;
            }
        }
        #endregion

        public StudentModel(Guid id, string firstName, string lastName, int age, string sex, bool isOutstanding)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Sex = sex;
            IsOutstanding = isOutstanding;
        }
    }
}
