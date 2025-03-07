using BankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Persistence.EntityConfigurations;

public class CreditTypeConfiguration : IEntityTypeConfiguration<CreditType>
{
    public void Configure(EntityTypeBuilder<CreditType> builder)
    {
        builder.ToTable("CreditTypes").HasKey(ct => ct.Id);

        builder.Property(ct => ct.Id).HasColumnName("Id");
        builder.Property(ct => ct.Name).HasColumnName("Name");
        builder.Property(ct => ct.Description).HasColumnName("Description");
        builder.Property(ct => ct.MinInterestRate).HasColumnName("MinInterestRate");
        builder.Property(ct => ct.MaxInterestRate).HasColumnName("MaxInterestRate");
        builder.Property(ct => ct.MinAmount).HasColumnName("MinAmount");
        builder.Property(ct => ct.MaxAmount).HasColumnName("MaxAmount");
        builder.Property(ct => ct.MinTermInMonths).HasColumnName("MinTermInMonths");
        builder.Property(ct => ct.MaxTermInMonths).HasColumnName("MaxTermInMonths");
        builder.Property(ct => ct.IsActive).HasColumnName("IsActive");
        builder.Property(ct => ct.Category).HasColumnName("Category");
        builder.Property(ct => ct.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(ct => ct.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ct => ct.IsDeleted).HasColumnName("IsDeleted");

        builder.HasQueryFilter(ct => !ct.IsDeleted);
    }
} 