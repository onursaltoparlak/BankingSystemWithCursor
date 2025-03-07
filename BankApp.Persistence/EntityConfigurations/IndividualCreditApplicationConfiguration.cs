using BankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Persistence.EntityConfigurations;

public class IndividualCreditApplicationConfiguration : IEntityTypeConfiguration<IndividualCreditApplication>
{
    public void Configure(EntityTypeBuilder<IndividualCreditApplication> builder)
    {
        builder.ToTable("IndividualCreditApplications").HasKey(ica => ica.Id);

        builder.Property(ica => ica.Id).HasColumnName("Id");
        builder.Property(ica => ica.IndividualCustomerId).HasColumnName("IndividualCustomerId");
        builder.Property(ica => ica.CreditTypeId).HasColumnName("CreditTypeId");
        builder.Property(ica => ica.NationalId).HasColumnName("NationalId").HasMaxLength(20);
        builder.Property(ica => ica.Amount).HasColumnName("Amount");
        builder.Property(ica => ica.TermInMonths).HasColumnName("TermInMonths");
        builder.Property(ica => ica.MonthlyIncome).HasColumnName("MonthlyIncome");
        builder.Property(ica => ica.EmployerName).HasColumnName("EmployerName");
        builder.Property(ica => ica.EmployerPhone).HasColumnName("EmployerPhone");
        builder.Property(ica => ica.Status).HasColumnName("Status");
        builder.Property(ica => ica.MonthlyPayment).HasColumnName("MonthlyPayment");
        builder.Property(ica => ica.RejectionReason).HasColumnName("RejectionReason");
        builder.Property(ica => ica.ApplicationDate).HasColumnName("ApplicationDate");
        builder.Property(ica => ica.EvaluationDate).HasColumnName("EvaluationDate");
        builder.Property(ica => ica.ApprovalDate).HasColumnName("ApprovalDate");
        builder.Property(ica => ica.RejectionDate).HasColumnName("RejectionDate");
        builder.Property(ica => ica.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(ica => ica.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ica => ica.IsDeleted).HasColumnName("IsDeleted");

        builder.HasQueryFilter(ica => !ica.IsDeleted);

        builder.HasOne(ica => ica.IndividualCustomer)
            .WithMany(ic => ic.CreditApplications)
            .HasForeignKey(ica => ica.IndividualCustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ica => ica.CreditType)
            .WithMany(ct => ct.IndividualCreditApplications)
            .HasForeignKey(ica => ica.CreditTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(ica => ica.EmployerName).HasMaxLength(100);
        builder.Property(ica => ica.EmployerPhone).HasMaxLength(20);
        builder.Property(ica => ica.RejectionReason).HasMaxLength(500);

        builder.HasIndex(ica => ica.NationalId);
    }
} 