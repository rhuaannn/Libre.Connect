using Libre.Connect.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libre.Connect.Infra.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable("Authors");
        builder.HasKey(x => x.Id);
        
        builder.OwnsOne(x => x.Name, nameBuilder =>
        {
            nameBuilder.Property(e => e.Value)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(255);
        });

        builder.HasMany(x => x.Books)
            .WithOne()
            .HasForeignKey("AuthorId")
            .OnDelete(DeleteBehavior.Restrict);
    }
}