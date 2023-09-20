using UserRegistration.API.Business.Domain.Handlers.PaginationHandler;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using System.Linq.Expressions;

namespace UserRegistration.UserRegistrationUnitTest.Utils;
public sealed class UtilTools
{
    public static PageList<T> BuildPageList<T>(List<T> entityList, int nextPage = 1) where T : class
    {
        var pageSize = 10;
        var pageNumber = 1;

        return new PageList<T>(entityList, entityList.Count, pageNumber, pageSize);
    }

    public static PageParams BuildPageParams(int pageNumber = 1, int pageSize = 10)
    {
        return new PageParams
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
        };
    }

    public static Func<IQueryable<T>, IIncludableQueryable<T, object>> BuildQueryableIncludeFunc<T>() where T : class =>
           It.IsAny<Func<IQueryable<T>, IIncludableQueryable<T, object>>>();

    public static Expression<Func<T, bool>> BuildPredicateFunc<T>() where T : class =>
           It.IsAny<Expression<Func<T, bool>>>();

    public static Expression<Func<T, T>> BuildSelectorFunc<T>() where T : class =>
        It.IsAny<Expression<Func<T, T>>>();
}
