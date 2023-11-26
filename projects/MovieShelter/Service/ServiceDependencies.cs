using Microsoft.Extensions.DependencyInjection;
using Service.Abstract;
using Service.Concrete;
using Service.Rules;


namespace Service;

public static class ServiceDependencies
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IMovieService, MovieService>();
        services.AddScoped<IPublisherService, PublisherService>();

        services.AddScoped<MovieRules>();
        services.AddScoped<CategoryRules>();
        services.AddScoped<PublisherRules>();

        return services;
    }
}
