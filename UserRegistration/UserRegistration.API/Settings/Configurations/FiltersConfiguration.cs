﻿using UserRegistration.API.Filters;

namespace UserRegistration.API.Settings.Configurations;

public static class FiltersConfiguration
{
    public static IServiceCollection AddFiltersConfiguration(this IServiceCollection services)
    {
        services.AddMvc(config => config.Filters.AddService<NotificationFilter>());
        services.AddMvc(config => config.Filters.AddService<UnitOfWorkFilter>());

        return services.AddScoped<NotificationFilter>()
                       .AddScoped<UnitOfWorkFilter>(); 
    }
}
