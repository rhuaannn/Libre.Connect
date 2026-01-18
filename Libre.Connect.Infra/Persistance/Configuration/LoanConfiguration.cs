using Libre.Connect.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libre.Connect.Infra.Persistance.Configuration;

public class LoanConfiguration : BaseConfiguration<Loan>
{
    public override void Configure(EntityTypeBuilder<Loan> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("Loans");

        builder.Property(l => l.DateLoan)
            .HasColumnName("loanDate")
            .HasColumnType("datetime2") 
            .IsRequired();

        builder.Property(l => l.ExpectedReturnDate)
            .HasColumnName("expectedReturnDate")
            .HasColumnType("datetime2")
            .IsRequired();

        builder.Property(l => l.ActualReturnDate)
            .HasColumnName("actualReturnDate")
            .HasColumnType("datetime2")
            .IsRequired(false);

        builder.Property(l => l.Fees)
            .HasColumnName("fees")
            .HasColumnType("decimal(18,2)")
            .HasDefaultValue(0)
            .IsRequired();
        
        builder.HasOne(l => l.Book)
            .WithMany(b => b.Loans)
            .HasForeignKey(l => l.BookId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Loan_Book");

        builder.HasOne(l => l.Member)
            .WithMany()
            .HasForeignKey(l => l.MemberId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Loan_Member");
            
        builder.HasIndex(l => l.ActualReturnDate)
               .HasDatabaseName("IX_Loan_ActiveLoans");
    }
}