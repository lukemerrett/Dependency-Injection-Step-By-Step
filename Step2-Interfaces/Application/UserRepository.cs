using StepTwo_Interfaces.Interfaces;
using StepTwo_Interfaces.Models;
using System;

namespace StepTwo_Interfaces.Application
{
    public class UserRepository : IUserRepository
    {
        private readonly IDatabaseConnection _databaseConnection;

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
