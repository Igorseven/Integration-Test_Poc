using UserRegistration.API.Business.Domain.Entities;
using UserRegistration.API.Business.Domain.Enums;
using UserRegistration.API.Business.Domain.Extensions;
using UserRegistration.API.Business.Domain.Handlers.ValidationHandler;
using FluentValidation;

namespace UserRegistration.API.Business.Domain.EntitiesValidation;
public sealed class ClientValidation : Validate<Client>
{
    public ClientValidation()
    {
        SetRules();
    }

    private void SetRules()
    {
        When(c => c.Emails.Any(), () =>
        {
            RuleFor(c => c.Emails).Must(e => CheckHaveAPrimaryEmail(e))
                .WithMessage(EMessage.Required.GetDescription().FormatTo("E-mail prinipal"));
        });

        When(c => c.Addresses.Any(), () =>
        {
            RuleFor(c => c.Addresses).Must(a => CheckHaveAPrimaryAddress(a))
                .WithMessage(EMessage.Required.GetDescription().FormatTo("E-mail prinipal"));
        });

        RuleForEach(c => c.Emails).SetValidator(new EmailAddressValidation());
        RuleForEach(c => c.Telephones).SetValidator(new TelephoneValidation());
        RuleForEach(c => c.Addresses).SetValidator(new AddressValidation());

        RuleFor(c => c.FullName).NotEmpty().Length(3, 150)
            .WithMessage(c => string.IsNullOrWhiteSpace(c.FullName)
            ? EMessage.Required.GetDescription().FormatTo("Nome completo")
            : EMessage.MoreExpected.GetDescription().FormatTo("Nome completo", "entre {MinLength} e {MaxLength}"));
    }

    private static bool CheckHaveAPrimaryEmail(List<EmailAddress> emails) =>
        emails.Any(e => e.EmailType == EEmailType.Main);

    private static bool CheckHaveAPrimaryAddress(List<Address> addresses) =>
        addresses.Any(a => a.AddressType == EAddressType.MainProperty);

}
