using UserRegistration.API.Business.Domain.Entities;
using UserRegistration.API.Business.Domain.Enums;
using UserRegistration.API.Business.Domain.Extensions;
using UserRegistration.API.Business.Domain.Handlers.ValidationHandler;
using FluentValidation;

namespace UserRegistration.API.Business.Domain.EntitiesValidation;
public sealed class EmailAddressValidation : Validate<EmailAddress>
{
    public EmailAddressValidation()
    {
        SetRules();
    }

    private void SetRules()
    {
        RuleFor(e => e.EmailType).IsInEnum().WithMessage(EMessage.InvalidFormat.GetDescription().FormatTo("Tipo do e-mail"));

        RuleFor(e => e.Email).EmailAddress().Length(7, 150)
            .WithMessage(e => !string.IsNullOrWhiteSpace(e.Email)
            ? EMessage.MoreExpected.GetDescription().FormatTo("E-mail", "entre {MinLength} e {MaxLength}")
            : EMessage.Required.GetDescription().FormatTo("E-mail"));
    }
}
