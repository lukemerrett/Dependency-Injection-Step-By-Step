using StepThree_InversionOfControl.Interfaces;
using StepThree_InversionOfControl.Models;
using System;
using System.Collections.Generic;

namespace StepThree_InversionOfControl.Application
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
