using StepOne_OldSchool.Models;
using System;
using System.Collections.Generic;

namespace StepOne_OldSchool.Interfaces
{
    public interface IAddressRepository
    {
        List<Address> GetAddressesForUser(Guid userId);
    }
}
