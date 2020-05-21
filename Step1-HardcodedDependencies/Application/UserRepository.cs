using StepOne_HardcodedDependencies.Models;
using System;

namespace StepOne_HardcodedDependencies.Application
{
    public class UserRepository
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
