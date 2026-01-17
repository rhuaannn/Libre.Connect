using Libre.Connect.Domain.Repositories;
using Libre.Connect.Domain.Repositories.Author;
using Libre.Connect.Domain.Repositories.Member;
using Libre.Connect.Infra.Repository;
using Libre.Connect.Infra.Repository.AuthorRepository;
using Libre.Connect.Infra.Repository.MemberRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Libre.Connect.Infra.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSqlServer(configuration);
        services.AddScoped<IReadOnlyBookRepository, BookRepository>();
        services.AddScoped<IWriteOnlyBookRepository, BookRepository>();
        services.AddScoped<IReadOnlyAuthorRepository, AuthorRepository>();
        services.AddScoped<IWriteOnlyAuthorRepository, AuthorRepository>();
        services.AddScoped<IWriteOnlyMemberRepository, MemberRepository>();
        services.AddScoped<IReadOnlyMemberRepository, MemberRepository>();
        return services;
    }

    private static void AddSqlServer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LibreConnectDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }
}