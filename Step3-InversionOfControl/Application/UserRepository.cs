using StepThree_InversionOfControl.Interfaces;
using StepThree_InversionOfControl.Models;
using System;

namespace StepThree_InversionOfControl.Application
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
