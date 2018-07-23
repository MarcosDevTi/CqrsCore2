using CqrsCore2.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CqrsCore2.Data.Maps
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.OwnsOne(s => s.Name, cb =>
            {
                cb.Property(c => c.FirstName)
                    .HasColumnName("FirstName")
                    .IsRequired()
                    .HasMaxLength(40);
                cb.Property(c => c.LastName)
                    .HasColumnName("LastName")
                    .IsRequired()
                    .HasMaxLength(80);
            });
            builder.OwnsOne(s => s.Email, cb =>
            {
                cb.Property(e => e.EmailAdress)
                    .HasColumnName("Email")
                    .IsRequired()
                    .HasMaxLength(150);
            });


        }
    }
}
