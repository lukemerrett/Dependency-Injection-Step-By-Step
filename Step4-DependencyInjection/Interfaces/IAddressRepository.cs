using StepFour_DependencyInjection.Models;
using System;
using System.Collections.Generic;

namespace StepFour_DependencyInjection.Interfaces
{
    public interface IAddressRepository
    {
        List<Address> GetAddressesForUser(Guid userId);
    }
}
