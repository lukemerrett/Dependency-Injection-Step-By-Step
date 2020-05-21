using StepOne_OldSchool.Models;
using System;

namespace StepOne_OldSchool.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(Guid userId);
    }
}
