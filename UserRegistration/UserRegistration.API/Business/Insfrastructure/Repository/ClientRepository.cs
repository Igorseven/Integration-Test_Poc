using UserRegistration.API.Business.Domain.Entities;
using UserRegistration.API.Business.Domain.Handlers.PaginationHandler;
using UserRegistration.API.Business.Domain.Handlers.PaginationHandler.PageParamsWithFilters;
using UserRegistration.API.Business.Domain.Interfaces.OthersContracts;
using UserRegistration.API.Business.Domain.Interfaces.RepositoryContracts;
using UserRegistration.API.Business.Insfrastructure.ORM.Context;
using UserRegistration.API.Business.Insfrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace UserRegistration.API.Business.Insfrastructure.Repository;
public sealed class ClientRepository : BaseRepository<Client>, IClientRepository
{
    private readonly IPaginationQueryService<Client> _paginationQueryService;

    public ClientRepository(ApplicationContext context,
                            IPaginationQueryService<Client> paginationQueryService)
        : base(context)
    {
        _paginationQueryService = paginationQueryService;
    }

    public async Task<bool> HaveInDatabaseAsync(Expression<Func<Client, bool>> where) => await _dbSet.AnyAsync(where);

    public async Task<PageList<Client>> FindAllWithpaginationAsync(PageParamsClientFilter pageParams,
                                                                   Expression<Func<Client, Client>>? selector = null)
    {
        IQueryable<Client> query = _dbSet;

        if (selector is not null)
            query = query.Select(selector);

        query = query.OrderByDescending(c => c.ClientId);

        return await _paginationQueryService.CreatePaginationAsync(query, pageParams.PageSize, pageParams.PageNumber);
    }

    public async Task<List<Client>> FindAllAsync(Func<IQueryable<Client>, IIncludableQueryable<Client, object>>? include = null)
    {
        IQueryable<Client> query = _dbSet;

        if (include is not null)
            query = include(query);

        return await query.AsNoTracking().ToListAsync();
    }

    public async Task<Client?> FindByPredicateAsync(Expression<Func<Client, bool>> predicate,
                                                    Func<IQueryable<Client>, IIncludableQueryable<Client, object>>? include = null,
                                                    bool asNoTracking = false)
    {
        IQueryable<Client> query = _dbSet;

        if (asNoTracking)
            query = query.AsNoTracking();

        if (include is not null)
            query = include(query);

        return await query.FirstOrDefaultAsync(predicate);
    }


    public async Task<bool> SaveAsync(Client client)
    {
        await _dbSet.AddAsync(client);

        return await SaveInDatabaseAsync();
    }

    public async Task<bool> UpdateAsync(Client client)
    {
        _dbSet.Update(client);

        return await SaveInDatabaseAsync();
    }

    public async Task<bool> DeleteAsync(int clientId) =>
        await _dbSet.Where(c => c.ClientId == clientId).ExecuteDeleteAsync() > 0;

}
