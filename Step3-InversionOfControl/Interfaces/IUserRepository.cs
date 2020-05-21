using StepThree_InversionOfControl.Models;
using System;

namespace StepThree_InversionOfControl.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(Guid userId);
    }
}
