using UserRegistration.API.Business.Domain.Entities;
using UserRegistration.API.Business.Domain.Handlers.PaginationHandler;
using UserRegistration.API.Business.Domain.Handlers.PaginationHandler.PageParamsWithFilters;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace UserRegistration.API.Business.Domain.Interfaces.RepositoryContracts;
public interface IClientRepository : IDisposable
{

    Task<bool> SaveAsync(Client client);
    Task<bool> UpdateAsync(Client client);
    Task<bool> DeleteAsync(int clientId);
    Task<bool> HaveInDatabaseAsync(Expression<Func<Client, bool>> where);

    Task<Client?> FindByPredicateAsync(Expression<Func<Client, bool>> predicate,
                                       Func<IQueryable<Client>, IIncludableQueryable<Client, object>>? include = null,
                                       bool asNoTracking = false);
    Task<PageList<Client>> FindAllWithpaginationAsync(PageParamsClientFilter pageParams,
                                                      Expression<Func<Client, Client>>? selector = null);

    Task<List<Client>> FindAllAsync(Func<IQueryable<Client>, IIncludableQueryable<Client, object>>? include = null);
}
