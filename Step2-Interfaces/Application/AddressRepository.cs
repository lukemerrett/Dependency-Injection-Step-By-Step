using StepTwo_Interfaces.Interfaces;
using StepTwo_Interfaces.Models;
using System;
using System.Collections.Generic;

namespace StepTwo_Interfaces.Application
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DatabaseConnection _databaseConnection;

        public AddressRepository()
        {
            _databaseConnection = new DatabaseConnection();
        }

        public List<Address> GetAddressesForUser(Guid userId)
        {
            return _databaseConnection.Get<List<Address>>(userId.ToString());
        }
    }
}
