using StepFour_DependencyInjection.Interfaces;
using StepFour_DependencyInjection.Models;
using System;

namespace StepFour_DependencyInjection.Application
{
    public class UserRepository : IUserRepository
    {
        private readonly IDatabaseConnection _databaseConnection;

        public UserRepository(IDatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public User GetUser(Guid userId)
        {
            return _databaseConnection.Get<User>(userId.ToString());
        }
    }
}
