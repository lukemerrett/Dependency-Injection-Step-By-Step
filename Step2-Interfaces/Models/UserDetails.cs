using System.Collections.Generic;

namespace StepTwo_Interfaces.Models
{
    public class UserDetails
    {
        public User User { get; set; }

        public List<Address> Addresses { get; set; }
    }
}
