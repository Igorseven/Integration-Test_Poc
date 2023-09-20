using UserRegistration.API.Business.ApplicationService.AutoMapper;

namespace UserRegistration.API.Business.Domain.Extensions;

public static class AutoMapperExtension
{
    public static TDestiantion MapTo<TSource, TDestiantion>(this TSource source) =>
        AutoMapperFactory.Mapper.Map<TSource, TDestiantion>(source);

    public static TDestiantion MapTo<TSource, TDestiantion>(this TSource source, TDestiantion destiantion) =>
        AutoMapperFactory.Mapper.Map(source, destiantion);
}
