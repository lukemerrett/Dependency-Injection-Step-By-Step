using System.Collections.Generic;

namespace StepFour_DependencyInjection.Models
{
    public class UserDetails
    {
        public User User { get; set; }

        public List<Address> Addresses { get; set; }
    }
}
