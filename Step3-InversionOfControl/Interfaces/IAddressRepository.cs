using StepThree_InversionOfControl.Models;
using System;
using System.Collections.Generic;

namespace StepThree_InversionOfControl.Interfaces
{
    public interface IAddressRepository
    {
        List<Address> GetAddressesForUser(Guid userId);
    }
}
