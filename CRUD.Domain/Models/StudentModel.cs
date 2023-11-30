namespace CRUD.Domain.Models
{
    public class StudentModel
    {
        #region Properties
        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public int Age { get; }
        public string Sex { get; }
        public bool IsOutstanding { get; set; }
        #endregion

        #region Constructor
        public StudentModel(Guid id, string firstName, string lastName, int age, string sex, bool isOutstanding)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Sex = sex;
            IsOutstanding = isOutstanding;
        }
        #endregion
    }
}
