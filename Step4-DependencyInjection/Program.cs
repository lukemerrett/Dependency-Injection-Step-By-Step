using Microsoft.Extensions.DependencyInjection;
using StepFour_DependencyInjection.Application;
using StepFour_DependencyInjection.Interfaces;
using System;
using System.Linq;

namespace StepFour_DependencyInjection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var userId = Guid.NewGuid();

            var serviceProvider = RegisterDependencies();

            var userDetailsService = serviceProvider.GetService<IUserDetailsService>();

            var userDetails = userDetailsService.GetDetailsForUser(userId);

            Console.WriteLine(userDetails);
        }

        private static ServiceProvider RegisterDependencies()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<IDatabaseConnection, DatabaseConnection>();
            serviceCollection.AddTransient<IUserRepository, UserRepository>();
            serviceCollection.AddTransient<IAddressRepository, AddressRepository>();
            serviceCollection.AddTransient<IUserDetailsService, UserDetailsService>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
