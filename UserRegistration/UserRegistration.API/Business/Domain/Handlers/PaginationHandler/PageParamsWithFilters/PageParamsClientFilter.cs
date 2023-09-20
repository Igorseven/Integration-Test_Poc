using UserRegistration.API.Business.Domain.Enums;

namespace UserRegistration.API.Business.Domain.Handlers.PaginationHandler.PageParamsWithFilters;
public sealed class PageParamsClientFilter : PageParams
{
    public EAddressType? AddressType { get; set; }
    public EEmailType? EmailType { get; set; }
}
