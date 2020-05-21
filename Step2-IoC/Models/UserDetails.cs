using System.Collections.Generic;

namespace StepOne_OldSchool.Models
{
    public class UserDetails
    {
        public User User { get; set; }

        public List<Address> Addresses { get; set; }
    }
}
