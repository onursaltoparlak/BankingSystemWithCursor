using BankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Persistence.EntityConfigurations;

public class IndividualCustomerConfiguration : IEntityTypeConfiguration<IndividualCustomer>
{
    public void Configure(EntityTypeBuilder<IndividualCustomer> builder)
    {
        builder.ToTable("IndividualCustomers").HasKey(ic => ic.Id);

        builder.Property(ic => ic.Id).HasColumnName("Id");
        builder.Property(ic => ic.NationalId).HasColumnName("NationalId");
        builder.Property(ic => ic.FirstName).HasColumnName("FirstName");
        builder.Property(ic => ic.LastName).HasColumnName("LastName");
        builder.Property(ic => ic.DateOfBirth).HasColumnName("DateOfBirth");
        builder.Property(ic => ic.PhoneNumber).HasColumnName("PhoneNumber");
        builder.Property(ic => ic.Email).HasColumnName("Email");
        builder.Property(ic => ic.Address).HasColumnName("Address");
        builder.Property(ic => ic.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(ic => ic.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ic => ic.IsDeleted).HasColumnName("IsDeleted");

        builder.HasQueryFilter(ic => !ic.IsDeleted);

        builder.HasIndex(ic => ic.NationalId, "UK_IndividualCustomers_NationalId").IsUnique();
        builder.HasIndex(ic => ic.Email, "UK_IndividualCustomers_Email").IsUnique();

        builder.Property(ic => ic.FirstName).HasMaxLength(50);
        builder.Property(ic => ic.LastName).HasMaxLength(50);
        builder.Property(ic => ic.NationalId).HasMaxLength(11);
        builder.Property(ic => ic.Email).HasMaxLength(100);
        builder.Property(ic => ic.PhoneNumber).HasMaxLength(20);
        builder.Property(ic => ic.Address).HasMaxLength(200);
    }
} 