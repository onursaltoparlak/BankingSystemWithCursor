using BankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Persistence.EntityConfigurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("ApplicationUsers").HasKey(au => au.Id);

        builder.Property(au => au.Id).HasColumnName("Id");
        builder.Property(au => au.PhoneNumber).HasColumnName("PhoneNumber").HasMaxLength(20);
        builder.Property(au => au.Address).HasColumnName("Address").HasMaxLength(200);
        builder.Property(au => au.CustomerId).HasColumnName("CustomerId");
        builder.Property(au => au.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(au => au.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(au => au.IsDeleted).HasColumnName("IsDeleted");

        builder.HasQueryFilter(au => !au.IsDeleted);

        builder.HasOne(au => au.Customer)
            .WithOne(c => c.ApplicationUser)
            .HasForeignKey<ApplicationUser>(au => au.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasDiscriminator<string>("UserType")
            .HasValue<IndividualApplicationUser>("Individual")
            .HasValue<CorporateApplicationUser>("Corporate");
    }
} 