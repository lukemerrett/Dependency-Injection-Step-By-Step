﻿using StepOne_HardcodedDependencies.Models;
using System;

namespace StepOne_HardcodedDependencies.Application
{
    public class UserDetailsService
    {
        private readonly UserRepository _userRepository;

        private readonly AddressRepository _addressRepository;

        public UserDetailsService()
        {
            _userRepository = new UserRepository();
            _addressRepository = new AddressRepository();
        }

        public UserDetails GetDetailsForUser(Guid userId)
        {
            var user = _userRepository.GetUser(userId);
            var addresses = _addressRepository.GetAddressesForUser(userId);

            return new UserDetails
            {
                User = user,
                Addresses = addresses
            };
        }
    }
}
