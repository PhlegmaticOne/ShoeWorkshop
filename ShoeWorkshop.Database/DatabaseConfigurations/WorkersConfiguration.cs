using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoeWorkshop.Domain.Models;

namespace ShoeWorkshop.Database
{
    internal class WorkersConfiguration : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
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
                   .WithOne(c => c.Worker)
                   .HasForeignKey(key => key.WorkerId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
