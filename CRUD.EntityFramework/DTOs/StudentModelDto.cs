namespace CRUD.EntityFramework.DTOs
{
    public class StudentModelDto
    {
        #region Properties
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public bool IsOutstanding { get; set; }
        #endregion
    }
}
