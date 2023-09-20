using UserRegistration.API.Business.Domain.Entities;
using UserRegistration.API.Business.Domain.Extensions;

namespace UserRegistration.UserRegistrationUnitTest.Extensions.MaskExtensionUnitTest;
public sealed class PhoneNumberMaskMethodUnitTest
{
    [Fact]
    [Trait("Processing", "Eight character phone number with ddd")]
    public void PhoneNumberMask_EightCharacterPhoneNumberWithDdd_ReturnFormattedString()
    {
        var telephone = new Telephone
        {
            Ddi = "55",
            Ddd = "18",
            PhoneNumber = "12345678"
        };

        var formattedResult = telephone.PhoneNumberMask();

        Assert.Equal("+55 (18) 1234-5678", formattedResult);
    }

    [Fact]
    [Trait("Processing", "Eight character phone number")]
    public void PhoneNumberMask_EightCharacterPhoneNumber_ReturnFormattedString()
    {
        var telephone = new Telephone
        {
            Ddi = "351",
            Ddd = null,
            PhoneNumber = "12345678"
        };

        var formattedResult = telephone.PhoneNumberMask();

        Assert.Equal("+351 1234-5678", formattedResult);
    }


    [Fact]
    [Trait("Processing", "Nine character phone number with ddd")]
    public void PhoneNumberMask_NineCharacterPhoneNumberWithDdd_ReturnFormattedString()
    {
        var telephone = new Telephone
        {
            Ddi = "55",
            Ddd = "18",
            PhoneNumber = "123456789"
        };

        var formattedResult = telephone.PhoneNumberMask();

        Assert.Equal("+55 (18) 12345-6789", formattedResult);
    }

    [Fact]
    [Trait("Processing", "Nine character phone number")]
    public void PhoneNumberMask_NineCharacterPhoneNumber_ReturnFormattedString()
    {
        var telephone = new Telephone
        {
            Ddi = "351",
            Ddd = null,
            PhoneNumber = "123456789"
        };

        var formattedResult = telephone.PhoneNumberMask();

        Assert.Equal("+351 12345-6789", formattedResult);
    }
}
