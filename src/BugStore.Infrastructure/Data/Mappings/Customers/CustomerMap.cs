using BugStore.Domain.Contexts.Customers.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BugStore.Infrastructure.Data.Mappings.Customers;

public class CustomerMap : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        
        builder.ToTable("Customers");

        builder
            .HasKey(x => x.Id)
            .HasName("PK_Customers");


        builder.Property(q => q.Name)
              .IsRequired()
              //.HasMaxLength(Customer.NameMaxLength)
              .HasColumnType("VARCHAR")
              .HasColumnName("Name");

        builder.Property(q => q.Email)
              .IsRequired()              
              .HasColumnType("VARCHAR")
              .HasColumnName("Email");

        builder.Property(q => q.Phone)
              .IsRequired()
              .HasColumnType("VARCHAR")
              .HasColumnName("Phone");

        builder.Property(q => q.BirthDate)
              .IsRequired()
              .HasColumnType("DATETIME")
              .HasColumnName("BirthDate");
    }
}