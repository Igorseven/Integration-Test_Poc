namespace UserRegistration.API.Business.Domain.Interfaces.OthersContracts;
public interface IUnitOfWork
{
    void CommitTransaction();
    void RolbackTransaction();
    void BeginTransaction();
}
