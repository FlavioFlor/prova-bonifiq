using Bogus;
using ProvaPub.Entities;

namespace ProvaPub.Tests.Mocks;

public static class CustomerMock
{
    private static readonly Faker<Customer> Faker = new Faker<Customer>()
            .RuleFor(customer => customer.Id, fake => fake.Random.Number(1, 1000))
            .RuleFor(customer => customer.Name, fake => fake.Person.FullName);

    public static Customer GetDefaultInstance() => Faker.Generate();

}
