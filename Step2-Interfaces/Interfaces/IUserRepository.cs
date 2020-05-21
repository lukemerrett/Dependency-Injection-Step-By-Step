using StepTwo_Interfaces.Models;
using System;

namespace StepTwo_Interfaces.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(Guid userId);
    }
}
