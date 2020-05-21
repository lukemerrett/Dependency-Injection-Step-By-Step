using StepFour_DependencyInjection.Models;
using System;

namespace StepFour_DependencyInjection.Interfaces
{
    public interface IUserDetailsService
    {
        UserDetails GetDetailsForUser(Guid userId);
    }
}
