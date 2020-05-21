using StepThree_InversionOfControl.Interfaces;
using StepThree_InversionOfControl.Models;
using System;

namespace StepThree_InversionOfControl.Application
{
    public class UserDetailsService: IUserDetailsService
    {
        private readonly IUserRepository _userRepository;

        private readonly IAddressRepository _addressRepository;

        public UserDetailsService(IUserRepository userRepository, IAddressRepository addressRepository)
        {
            _userRepository = userRepository;
            _addressRepository = addressRepository;
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
