using StepOne_OldSchool.Models;
using System;

namespace StepOne_OldSchool.Interfaces
{
    public interface IUserDetailsService
    {
        UserDetails GetDetailsForUser(Guid userId);
    }
}
