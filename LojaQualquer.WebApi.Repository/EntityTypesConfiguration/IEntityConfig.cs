using Microsoft.EntityFrameworkCore;

namespace LojaQualquer.WebApi.Repository.EntityTypesConfiguration
{
    public interface IEntityConfig
    {
        void ApplyConfiguration(ModelBuilder modelBuilder);
    }
}