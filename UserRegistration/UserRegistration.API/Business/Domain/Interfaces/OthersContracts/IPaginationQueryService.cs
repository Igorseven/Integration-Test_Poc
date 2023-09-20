using UserRegistration.API.Business.Domain.Handlers.PaginationHandler;

namespace UserRegistration.API.Business.Domain.Interfaces.OthersContracts;
public interface IPaginationQueryService<T> where T : class
{
    Task<PageList<T>> CreatePaginationAsync(IQueryable<T> source, int pageSize, int pageNumber);
}
