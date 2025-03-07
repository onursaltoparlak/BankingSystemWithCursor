using BankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Persistence.EntityConfigurations;

public class CorporateCustomerConfiguration : IEntityTypeConfiguration<CorporateCustomer>
{
    public void Configure(EntityTypeBuilder<CorporateCustomer> builder)
    {
        builder.ToTable("CorporateCustomers");

        builder.Property(cc => cc.Id).HasColumnName("Id");
        builder.Property(cc => cc.CompanyName).HasColumnName("CompanyName");
        builder.Property(cc => cc.TaxNumber).HasColumnName("TaxNumber");
        builder.Property(cc => cc.TaxOffice).HasColumnName("TaxOffice");
        builder.Property(cc => cc.PhoneNumber).HasColumnName("PhoneNumber");
        builder.Property(cc => cc.Address).HasColumnName("Address");
        builder.Property(cc => cc.EmployeeCount).HasColumnName("EmployeeCount");
        builder.Property(cc => cc.AnnualRevenue).HasColumnName("AnnualRevenue");
        builder.Property(cc => cc.EstablishmentDate).HasColumnName("EstablishmentDate");
        builder.Property(cc => cc.CompanyType).HasColumnName("CompanyType");
        builder.Property(cc => cc.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(cc => cc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cc => cc.IsDeleted).HasColumnName("IsDeleted");

        builder.HasQueryFilter(cc => !cc.IsDeleted);

        builder.HasOne(cc => cc.ApplicationUser)
            .WithOne()
            .HasForeignKey<CorporateCustomer>("ApplicationUserId");

        builder.HasMany(cc => cc.CreditApplications)
            .WithOne(ca => ca.CorporateCustomer)
            .HasForeignKey(ca => ca.CorporateCustomerId);

        builder.HasIndex(cc => cc.TaxNumber, "UK_CorporateCustomers_TaxNumber").IsUnique();
        builder.HasIndex(cc => cc.Email, "UK_CorporateCustomers_Email").IsUnique();

        builder.Property(cc => cc.CompanyName).HasMaxLength(100);
        builder.Property(cc => cc.TaxNumber).HasMaxLength(10);
        builder.Property(cc => cc.CompanyType).HasMaxLength(100);
        builder.Property(cc => cc.Email).HasMaxLength(100);
        builder.Property(cc => cc.PhoneNumber).HasMaxLength(20);
        builder.Property(cc => cc.Address).HasMaxLength(200);
    }
} 