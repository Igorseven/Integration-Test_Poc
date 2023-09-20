using Microsoft.EntityFrameworkCore.Infrastructure;
using UserRegistration.API.Business.Insfrastructure.ORM.Context;
using UserRegistration.API.Business.Domain.Interfaces.OthersContracts;

namespace UserRegistration.API.Business.Insfrastructure.ORM.UoW;
public sealed class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseFacade _databaseFacade;

    public UnitOfWork(ApplicationContext dbcontext)
    {
        _databaseFacade = dbcontext.Database;
    }

    public void CommitTransaction()
    {
        try
        {
            _databaseFacade.CommitTransaction();
        }
        catch
        {
            RolbackTransaction();
            throw;
        }
    }

    public void RolbackTransaction() => _databaseFacade.RollbackTransaction();

    public void BeginTransaction() => _databaseFacade.BeginTransaction();
}
