using Libre.Connect.Domain.Entites;
using Libre.Connect.Domain.Entites.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libre.Connect.Infra.Persistance.Configuration;

public class BookConfiguration : BaseConfiguration<Book>
{
    public override void Configure(EntityTypeBuilder<Book> builder)
    {
        base.Configure(builder);
        builder.ToTable("Books");
        
        builder.Property(e => e.Name)
            .HasConversion(v=> v.Value, v=>Name.Create(v))
            .HasColumnName("name")
            .HasColumnType("varchar(255)")
            .IsRequired();
        
        builder.HasOne(d => d.Author)
            .WithMany(p => p.Books)
            .HasForeignKey(d => d.AuthorId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Book_Author");

        builder.Property(d => d.Publisher)
            .HasColumnName("publisher")
            .HasColumnType("varchar(255)")
            .IsRequired();

        builder.Property(d => d.DataLancamento)
            .HasColumnName("dataLancamento")
            .HasColumnType("datetime2")
            .IsRequired();
        
        builder.Property(e => e.IsAvailable)
            .HasColumnName("isAvailable")
            .HasDefaultValue(true)
            .IsRequired();
            
        builder.HasMany(b => b.Loans)
            .WithOne(l => l.Book)
            .HasForeignKey(l => l.BookId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasIndex(e => e.Name)
            .HasDatabaseName("UQ_BOOK_NAME")
            .IsUnique();
        
    }
    
}