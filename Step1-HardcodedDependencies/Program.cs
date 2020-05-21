using StepOne_HardcodedDependencies.Application;
using System;

namespace StepOne_HardcodedDependencies
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var userId = Guid.NewGuid();

            var userDetailsService = new UserDetailsService();

            var userDetails = userDetailsService.GetDetailsForUser(userId);

            Console.WriteLine(userDetails);
        }
    }
}
