using StepFour_DependencyInjection.Interfaces;
using StepFour_DependencyInjection.Models;
using System;
using System.Collections.Generic;

namespace StepFour_DependencyInjection.Application
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IDatabaseConnection _databaseConnection;

        public AddressRepository(IDatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public List<Address> GetAddressesForUser(Guid userId)
        {
            return _databaseConnection.Get<List<Address>>(userId.ToString());
        }
    }
}
