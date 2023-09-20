using UserRegistration.API.Business.Domain.Handlers.ValidationHandler;

namespace UserRegistration.API.Business.Domain.Interfaces.OthersContracts;
public interface IValidate<T> where T : class
{
    Task<ValidationResponse> ValidationAsync(T entity);
    ValidationResponse Validation(T entity);
}
