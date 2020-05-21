# Dependency Injection Step By Step

Example projects explaining inversion of control and dependency injection 

## Pre Requisites

* Requires the [.Net Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet-core/3.1)

## Building

From the root of the repository run:

```
dotnet build
```

This will restore any dependencies and build the project.

## Inversion of Control and Dependency Injection Walkthrough.

This solution contains 4 projects each showing a different stage of moving an example project from hardcoded dependencies to using dependency injection.

In each project we have this example code:

* Program.cs -> Entry point into the application, calls the UserDetailsService
* UserDetailsService.cs -> Responsible for getting user details and addresses, depends on the UserRepository and AddressRepository
* UserRepository.cs -> Reponsible for getting user details from the database, depends on the DatabaseConnection
* AddressRepository.cs -> Reponsible for getting a user's addresses from the database, depends on the DatabaseConnection
* DatabaseConnection.cs -> Responsible for connecting to and querying the database.

### Step 1:  Hardcoded Dependencies

In the below example where `UserDetailsService` needs to access two repositories, it is creating new instances of each repository within its constructor.

```csharp
public class UserDetailsService
{
    private readonly UserRepository _userRepository;

    private readonly AddressRepository _addressRepository;

    public UserDetailsService()
    {
        _userRepository = new UserRepository();
        _addressRepository = new AddressRepository();
    }
```

The same is then true inside the repositories, they take the responsibility of creating new instances of their dependencies:

```csharp
public class UserRepository
{
    private readonly DatabaseConnection _databaseConnection;

    public UserRepository()
    {
        _databaseConnection = new DatabaseConnection();
    }
```

There are a number of problems with doing this:

1. The code becomes impossible to unit test as we have no way of isolating the dependencies
    * In the second example I have no way overriding how the `DatabaseConnection` behaves, so I cannot write in memory tests that to see what happens if the database returns different things or throws an exception.
    * In it's current state the application can only be integration tested, which is more expensive in terms of execution time and sits higher up the test pyramid
2. Leads to duplication across the code base
    * In the second example we have 2 repositories, both that create their own `DatabaseConnection`
    * If I wanted to replace the behaviour of `DatabaseConnection` in the future or change it's constructor, I'd have to modify 2 places
3. We are tying the service to concrete implementations rather than interfaces
    * `UserDetailsService` shouldn't need to know exactly which `UserRepository` to instantiate
    * All it needs to know is the contract of behaviour it expects, we can achieve this with an interface

By tying the higher level code to lower level implementations we are breaking the [Dependency Inversion Principle](https://en.wikipedia.org/wiki/Dependency_inversion_principle) of [SOLID](https://en.wikipedia.org/wiki/SOLID), which states that:

> High-level modules should not depend on low-level modules. Both should depend on abstractions

This is important when building complex systems as if we stick to the principle it allows us to be more flexible with how concrete implementations of modules behave without having to change anything that depends on them.

The next 3 steps show how we can modify the code base to honour the [Dependency Inversion Principle](https://en.wikipedia.org/wiki/Dependency_inversion_principle).

### Step 2: Interfaces

The first step is to seperate out the contract of how to use a module with the behaviour itself, decoupling higher level modules from the lower level ones.

AKA: We need to start using interfaces for our Repositories and Database Connection.

In this project we have done the following:

1. Introduce the interfaces `IUserDetailsService`, `IUserRepository`, `IAddresRepository` and `IDatabaseConnection`
2. Update each concrete implementation to inherit it's relevant interface, e.g: `public class UserRepository : IUserRepository`
3. Updated each higher level module so it holds a reference to the interface rather than the concrete implementation

```csharp
public class UserRepository : IUserRepository
{
    private readonly IDatabaseConnection _databaseConnection;

    public UserRepository()
    {
        _databaseConnection = new DatabaseConnection();
    }
```

This seperation between behaviour and the contract is a good first step, however we still have a problem.  The `UserRepository` in the above example is still taking reponsibility for creating the concrete instance of the `DatabaseConnection`, so the two are still tightly coupled and cannot be unit tested.

This leads us onto step 3.

### Step 3: Inversion of Control

Next we need to invert how a high level module receives the low level modules it depends on.

So rather than this:

```csharp
public class UserRepository : IUserRepository
{
    private readonly IDatabaseConnection _databaseConnection;

    public UserRepository()
    {
        _databaseConnection = new DatabaseConnection();
    }
```

We pass the dependency through the constructor like this:

```csharp
public class UserRepository : IUserRepository
{
    private readonly IDatabaseConnection _databaseConnection;

    public UserRepository(IDatabaseConnection databaseConnection)
    {
        _databaseConnection = databaseConnection;
    }
```

This seperation means the `UserRepository` doesn't need to know exactly which `IDatabaseConnection` it is using, just that the provided connection behaves in a way that honours the contract of behaviour defined in the interface.

This step means we can now unit test the `UserRepository` as we can mock the behaviour of the `IDatabaseConnection` to work in different ways in memory, without having to actually have it connect to a database.

Our program entry point then looks like this:

```csharp
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
```

At the top level we control the behaviour to be passed in to each service and repository.  This gives us better control about how each underlying module behaves, and gives us a single place to change which particular concrete implementation is used.

There is one more problem though, as our system grows in complexity we have to continue updating the program entry point to pass new dependencies into their relevant constructors, including any duplication (such as where the repositories both need the database connection).  It can all get a bit messy, especially if the constructors start taking lots of arguments.

This then leads us on to dependency injection in step 4

### Step 4: Dependency Injection

In the last stage we are only modifying the program's main method like so:

```csharp
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
```

Here we are using the .Net Core Framework's own dependency injection package called `Microsoft.Extensions.DependencyInjection`.

A dependency injection framework like this is responsible for registering all the interfaces and implementations in a system and how long they live for.

What we're saying with this statement `serviceCollection.AddTransient<IDatabaseConnection, DatabaseConnection>();` is that whenever we ask for a `IDatabaseConnection` in this system, it should create a new `DatabaseConnection` instance.  The `AddTransient` means this is a transient dependency so it will create a new instance every time we ask for one.  If we used `AddSingleton` it will only create 1 instance and reuse it whenever we ask for it.

When we call `var userDetailsService = serviceProvider.GetService<IUserDetailsService>();`; what this is doing is creating a new instance of the `UserDetailsService` class and using all the registered services to work out what instances it needs to pass into the services constructor.

The benefit here is that if we were to create a new class inheriting `IDatabaseConnection` we could change the behaviour of our whole system just by modifying the `serviceCollection.AddTransient<IDatabaseConnection, DatabaseConnection>();` line to use the new type.