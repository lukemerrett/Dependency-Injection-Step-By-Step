using StepThree_InversionOfControl.Application;
using System;

namespace StepThree_InversionOfControl
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var userId = Guid.NewGuid();

            var databaseConnection = new DatabaseConnection();
            var userRepository = new UserRepository(databaseConnection);
            var addressRepository = new AddressRepository(databaseConnection);

            var userDetailsService = new UserDetailsService(userRepository, addressRepository);

            var userDetails = userDetailsService.GetDetailsForUser(userId);

            Console.WriteLine(userDetails);
        }
    }
}
