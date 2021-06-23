using LojaQualquer.WebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaQualquer.WebApi.Repository.EntityTypesConfiguration
{
    public class ProductConfig : BaseEntityConfig<Product>, IEntityConfig
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(e => e.Id);

            builder
                .HasIndex(e => e.Name)
                .IsUnique();

            builder
                .Property(e => e.Name)
                .HasColumnName("Name")
                .HasMaxLength(128)
                .IsRequired();

            builder
                .Property(e => e.Category)
                .HasColumnName("Category")
                .IsRequired();

            builder
                .Property(e => e.Price)
                .HasColumnName("Price")
                .HasColumnType("decimal(10, 2)")
                .IsRequired();
        }
    }
}