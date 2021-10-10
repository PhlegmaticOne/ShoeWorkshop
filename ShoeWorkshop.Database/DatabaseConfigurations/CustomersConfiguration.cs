using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoeWorkshop.Domain.Models;

namespace ShoeWorkshop.Database
{
    internal class CustomersConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(key => key.Id);

            builder.Property(w => w.Name)
                   .HasMaxLength(30)
                   .IsRequired();

            builder.Property(w => w.Surname)
                   .HasMaxLength(30)
                   .IsRequired();

            builder.Property(w => w.Phone)
                   .HasMaxLength(13)
                   .IsFixedLength()
                   .IsRequired();

            builder.HasMany(r => r.Repairs)
                   .WithOne(c => c.Customer)
                   .HasForeignKey(key => key.CustomerId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
