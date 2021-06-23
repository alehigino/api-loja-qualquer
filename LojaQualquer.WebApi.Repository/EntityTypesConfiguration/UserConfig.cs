using LojaQualquer.WebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaQualquer.WebApi.Repository.EntityTypesConfiguration
{
    public class UserConfig : BaseEntityConfig<User>, IEntityConfig
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(e => e.Id);

            builder
                .HasIndex(e => e.Email)
                .IsUnique();

            builder
                .Property(e => e.Name)
                .HasColumnName("Name")
                .HasMaxLength(128)
                .IsRequired();

            builder
                .Property(e => e.Email)
                .HasColumnName("Email")
                .HasMaxLength(128)
                .IsRequired();

            builder
                .Property(e => e.Password)
                .HasColumnName("Password")
                .HasMaxLength(128)
                .IsRequired();

            builder.HasData(
                new User
                {
                    Id = 1,
                    Name = "Administrador",
                    Email = "admin@lojaqualquer.com.br",
                    Password = "AQAAAAEAACcQAAAAEKfQncAI8gUDZY1Nf9lKu3+qeFRVkJgJMF3Ka3Ku/0eYJNOzkLgJmpRhQS/d71bV9Q=="
                },
                new User
                {
                    Id = 2,
                    Name = "Usuario",
                    Email = "usuario@lojaqualquer.com.br",
                    Password = "AQAAAAEAACcQAAAAEHaDiz/ImdoZTlNaube3GYffTNAvsXtmZwmqLd6Xu5DV2qYnIm3UflL+Z9oSeMTnng=="
                }
            );
        }
    }
}