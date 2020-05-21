using StepOne_OldSchool.Application;
using System;

namespace StepOne_OldSchool
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
