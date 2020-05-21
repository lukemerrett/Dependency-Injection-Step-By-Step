using StepOne_OldSchool.Interfaces;
using StepOne_OldSchool.Models;
using System;

namespace StepOne_OldSchool.Application
{
    public class UserDetailsService: IUserDetailsService
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
