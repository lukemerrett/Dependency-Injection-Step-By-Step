using StepOne_OldSchool.Interfaces;
using StepOne_OldSchool.Models;
using System;

namespace StepOne_OldSchool.Application
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseConnection _databaseConnection;

        public UserRepository()
        {
            _databaseConnection = new DatabaseConnection();
        }

        public User GetUser(Guid userId)
        {
            return _databaseConnection.Get<User>(userId.ToString());
        }
    }
}
