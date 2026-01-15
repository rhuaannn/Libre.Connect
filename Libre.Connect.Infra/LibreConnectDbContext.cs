using Libre.Connect.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Libre.Connect.Infra;

public class LibreConnectDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Loan> Loans { get; set; }

    public LibreConnectDbContext(DbContextOptions<LibreConnectDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibreConnectDbContext).Assembly);
    }
}