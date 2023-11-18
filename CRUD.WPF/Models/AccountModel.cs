using System;

namespace CRUD.WPF.Models
{
    public class AccountModel
    {
        #region Properties
        public string Username { get; }
        public string Password { get; }
        public string FirstName { get; }
        public string LastName { get; }
        #endregion

        #region Constructor
        public AccountModel(string username, string password, string firstName, string lastName)
        {
            Username = username;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
        }
        #endregion
    }
}
