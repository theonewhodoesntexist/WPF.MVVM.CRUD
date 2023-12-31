﻿namespace CRUD.Domain.Models
{
    public class AccountModel : IModel
    {
        #region Properties
        public Guid Id { get; }
        public string Username { get; }
        public string Password { get; }
        public string FirstName { get; }
        public string LastName { get; }

        #endregion

        #region Constructor
        public AccountModel(Guid id, string username, string password, string firstName, string lastName)
        {
            Id = id;
            Username = username;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
        }
        #endregion
    }
}
