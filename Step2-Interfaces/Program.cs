using StepTwo_Interfaces.Application;
using System;

namespace StepTwo_Interfaces
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
