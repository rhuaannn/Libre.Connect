using Libre.Connect.Application.UseCase.Author;
using Libre.Connect.Application.UseCase.CreateBook;
using Microsoft.Extensions.DependencyInjection;

namespace Libre.Connect.Application.DI;

public static class DependencyInjenction
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<RegisterBookUseCase>();
        services.AddScoped<RegisterAuthorUseCase>();
        
        return services;
    }
    
}