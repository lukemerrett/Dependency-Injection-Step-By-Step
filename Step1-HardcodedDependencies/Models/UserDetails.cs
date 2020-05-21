using System.Collections.Generic;

namespace StepOne_HardcodedDependencies.Models
{
    public class UserDetails
    {
        public User User { get; set; }

        public List<Address> Addresses { get; set; }
    }
}
