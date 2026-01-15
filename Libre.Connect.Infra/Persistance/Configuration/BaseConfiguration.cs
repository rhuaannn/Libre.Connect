using Libre.Connect.Domain.Entites.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libre.Connect.Infra.Persistance.Configuration;

public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnType("datetime2")
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(e => e.UpdatedAt)
            .HasColumnType("datetime2");
    }
    
}