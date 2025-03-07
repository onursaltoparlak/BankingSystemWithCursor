using BankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Persistence.EntityConfigurations;

public class CorporateCreditApplicationConfiguration : IEntityTypeConfiguration<CorporateCreditApplication>
{
    public void Configure(EntityTypeBuilder<CorporateCreditApplication> builder)
    {
        builder.ToTable("CorporateCreditApplications").HasKey(cca => cca.Id);

        builder.Property(cca => cca.Id).HasColumnName("Id");
        builder.Property(cca => cca.CorporateCustomerId).HasColumnName("CorporateCustomerId");
        builder.Property(cca => cca.CreditTypeId).HasColumnName("CreditTypeId");
        builder.Property(cca => cca.Amount).HasColumnName("Amount");
        builder.Property(cca => cca.TermInMonths).HasColumnName("TermInMonths");
        builder.Property(cca => cca.AnnualRevenue).HasColumnName("AnnualRevenue");
        builder.Property(cca => cca.EmployeeCount).HasColumnName("EmployeeCount");
        builder.Property(cca => cca.TradeRegistryNumber).HasColumnName("TradeRegistryNumber");
        builder.Property(cca => cca.Status).HasColumnName("Status");
        builder.Property(cca => cca.MonthlyPayment).HasColumnName("MonthlyPayment");
        builder.Property(cca => cca.RejectionReason).HasColumnName("RejectionReason");
        builder.Property(cca => cca.ApplicationDate).HasColumnName("ApplicationDate");
        builder.Property(cca => cca.EvaluationDate).HasColumnName("EvaluationDate");
        builder.Property(cca => cca.ApprovalDate).HasColumnName("ApprovalDate");
        builder.Property(cca => cca.RejectionDate).HasColumnName("RejectionDate");
        builder.Property(cca => cca.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(cca => cca.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cca => cca.IsDeleted).HasColumnName("IsDeleted");

        builder.HasQueryFilter(cca => !cca.IsDeleted);

        builder.HasOne(cca => cca.CorporateCustomer)
            .WithMany(cc => cc.CreditApplications)
            .HasForeignKey(cca => cca.CorporateCustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(cca => cca.CreditType)
            .WithMany(ct => ct.CorporateCreditApplications)
            .HasForeignKey(cca => cca.CreditTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(cca => cca.TradeRegistryNumber).HasMaxLength(50);
        builder.Property(cca => cca.RejectionReason).HasMaxLength(500);
    }
} 