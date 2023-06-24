using Domain.Customers;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
            customerId => customerId.Value,
            value => new CustomerId(value));

        builder.Property(c => c.Name).HasMaxLength(50);

        builder.Property(c => c.LastName).HasMaxLength(50);

        builder.Ignore(c => c.FullName);

        builder.Property(c => c.Email).HasMaxLength(255);

        builder.HasIndex(c => c.Email).IsUnique();

        builder.Property(c => c.PhoneNumber).HasConversion(
            phoneNumber => phoneNumber.Value,
            value => PhoneNumber.Create(value)!)
            .HasMaxLength(9);

        builder.OwnsOne(c => c.Address, addressBuilder => {

            addressBuilder.Property(a => a.Country).HasMaxLength(3);

            addressBuilder.Property(a => a.Line1).HasMaxLength(20);

            addressBuilder.Property(a => a.Line2).HasMaxLength(20).IsRequired(false);

            addressBuilder.Property(a => a.City).HasMaxLength(40);

            addressBuilder.Property(a => a.State).HasMaxLength(40);

            addressBuilder.Property(a => a.ZipCode).HasMaxLength(10).IsRequired(false);
        });

        builder.Property(c => c.Active);
    }
}
