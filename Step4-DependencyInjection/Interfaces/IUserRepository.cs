using StepFour_DependencyInjection.Models;
using System;

namespace StepFour_DependencyInjection.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(Guid userId);
    }
}
