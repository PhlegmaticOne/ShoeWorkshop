using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoeWorkshop.Domain.Models;
using System;

namespace ShoeWorkshop.Database
{
    internal class RepairsConfiguration : IEntityTypeConfiguration<Repair>
    {
        public void Configure(EntityTypeBuilder<Repair> builder)
        {
            builder.HasKey(key => key.Id);

            builder.Property(p => p.RepairType)
                   .HasConversion(v => v.ToString(), v => (RepairType)Enum.Parse(typeof(RepairType), v))
                   .IsRequired();

            builder.Property(p => p.Price).IsRequired();

            builder.Property(p => p.PaymentTime)
                            .HasColumnType("datetime")
                            .IsRequired();

            builder.Property(p => p.EndOfRepair)
                            .HasColumnType("datetime")
                            .IsRequired();

            builder.Property(p => p.IsEnded).HasDefaultValue(false);

            builder.HasOne(w => w.Customer)
                .WithMany(r => r.Repairs)
                .HasForeignKey(key => key.CustomerId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(w => w.Worker)
                .WithMany(r => r.Repairs)
                .HasForeignKey(key => key.WorkerId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
