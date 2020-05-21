using StepTwo_Interfaces.Models;
using System;
using System.Collections.Generic;

namespace StepTwo_Interfaces.Interfaces
{
    public interface IAddressRepository
    {
        List<Address> GetAddressesForUser(Guid userId);
    }
}
