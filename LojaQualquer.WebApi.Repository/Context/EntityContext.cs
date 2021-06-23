using LojaQualquer.WebApi.Repository.EntityTypesConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace LojaQualquer.WebApi.Repository.Context
{
    public class EntityContext : DbContext
    {
        public IConfiguration Configuration { get; set; }

        public EntityContext(DbContextOptions<EntityContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("Default"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ApplyEntityConfiguration(model);
        }

        private void ApplyEntityConfiguration(ModelBuilder modelBuilder)
        {
            var entityConfigTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(e => e.GetTypes())
                .Where(w => typeof(IEntityConfig).IsAssignableFrom(w) && !w.IsInterface && !w.IsAbstract)
                .ToList();

            var entityConfigInstances = entityConfigTypes.Select(ec => (IEntityConfig) Activator.CreateInstance(ec));

            foreach(var entityConfig in entityConfigInstances) { entityConfig.ApplyConfiguration(modelBuilder);}
        }
    }
}
