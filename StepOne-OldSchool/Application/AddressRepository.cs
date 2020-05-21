﻿using StepOne_OldSchool.Models;
using System;
using System.Collections.Generic;

namespace StepOne_OldSchool.Application
{
    public class AddressRepository
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
