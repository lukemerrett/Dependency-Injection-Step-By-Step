using StepThree_InversionOfControl.Models;
using System;

namespace StepThree_InversionOfControl.Interfaces
{
    public interface IUserDetailsService
    {
        UserDetails GetDetailsForUser(Guid userId);
    }
}
