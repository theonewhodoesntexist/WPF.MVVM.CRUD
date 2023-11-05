namespace CRUD.WPF.Models
{
    public class StudentModel
    {
        #region Properties
        public string FirstName { get; }
        public string LastName { get; }
        public int Age { get; }
        public string Sex { get; }
        public bool IsOutstanding { get; }
        #endregion

        public StudentModel(string firstName, string lastName, int age, string sex, bool isOutstanding)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Sex = sex;
            IsOutstanding = isOutstanding;
        }
    }
}
