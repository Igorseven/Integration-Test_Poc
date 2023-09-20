using Bogus.Extensions;
using UserRegistration.API.Business.Domain.EntitiesValidation;
using UserRegistration.UserRegistrationUnitTest.Builders;

namespace UserRegistration.UserRegistrationUnitTest.Validations;
public sealed class CustomerValidationUnitTest
{
    private readonly ClientValidation _validation;

    public CustomerValidationUnitTest()
    {
        _validation = new();
    }

    [Fact]
    [Trait("Success", "Perfect setting")]
    public async Task CustomerValidation_PerfectSetting_ReturnTrue()
    {
        var fullName = "Tester test testing";

        var customer = ClientBuilderTest.NewObject()
                                          .WithFullName(fullName)
                                          .WithAllRelationships()
                                          .DomainObject();

        var validationResponse = await _validation.ValidationAsync(customer);

        Assert.True(validationResponse.Valid);
    }



    public static IEnumerable<object[]> InvalidFullName()
    {
        return new List<object[]>
        {
            new object[] {new Bogus.Faker().Person.FirstName.ClampLength(1, 2)},
            new object[] {new Bogus.Faker().Person.FirstName.ClampLength(151, 155)},
            new object[] {""},
            new object[] {"      "},
        };
    }

    [Theory]
    [Trait("Failed", "Invalid full name")]
    [MemberData(nameof(InvalidFullName))]
    public async Task CustomerValidation_InvalidFullName_ReturnFalse(string fullName)
    {

        var customer = ClientBuilderTest.NewObject()
                                          .WithFullName(fullName)
                                          .WithAllRelationships()
                                          .DomainObject();

        var validationResponse = await _validation.ValidationAsync(customer);

        Assert.False(validationResponse.Valid);
    }
}
