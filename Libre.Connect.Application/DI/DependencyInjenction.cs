using Libre.Connect.Application.UseCase.Author;
using Libre.Connect.Application.UseCase.Author.GetAll;
using Libre.Connect.Application.UseCase.Author.Remove;
using Libre.Connect.Application.UseCase.Book.GetAll;
using Libre.Connect.Application.UseCase.Book.Remove;
using Libre.Connect.Application.UseCase.CreateBook;
using Libre.Connect.Application.UseCase.Member;
using Libre.Connect.Application.UseCase.Member.GetAll;
using Microsoft.Extensions.DependencyInjection;

namespace Libre.Connect.Application.DI;

public static class DependencyInjenction
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<RegisterBookUseCase>();
        services.AddScoped<RegisterAuthorUseCase>();
        services.AddScoped<GetAuthorUseCase>();
        services.AddScoped<GetBookUseCase>();
        services.AddScoped<RemoveBookUseCase>();
        services.AddScoped<RemoveAuthorUseCase>();
        services.AddScoped<RegisterMemberUseCase>();
        services.AddScoped<GetAllMemberUseCase>();
        
        return services;
    }
    
}