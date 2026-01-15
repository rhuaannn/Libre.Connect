using Libre.Connect.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libre.Connect.Infra.Configurations;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.ToTable("Members");
        
        builder.HasKey(x => x.Id);
        builder.OwnsOne(x => x.Email, emailBuilder =>
        {
                 emailBuilder.Property(e => e.Value) 
                .HasColumnName("Email") 
                .IsRequired()
                .HasMaxLength(255);
                
            emailBuilder.HasIndex(e => e.Value).IsUnique(); 
        });

        builder.OwnsOne(x => x.Name, nameBuilder =>
        {
            nameBuilder.Property(e => e.Value)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(255);
        });
    }
}