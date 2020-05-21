using StepTwo_Interfaces.Models;
using System;

namespace StepTwo_Interfaces.Interfaces
{
    public interface IUserDetailsService
    {
        UserDetails GetDetailsForUser(Guid userId);
    }
}
