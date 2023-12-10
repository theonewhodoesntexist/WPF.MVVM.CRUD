namespace CRUD.EntityFramework.DTOs
{
    public class AccountModelDto
    {
        #region Properties
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        #endregion
    }
}
