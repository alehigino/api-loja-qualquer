using LojaQualquer.WebApi.Domain.Entities;
using LojaQualquer.WebApi.Domain.Interfaces.Repositories;
using LojaQualquer.WebApi.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace LojaQualquer.WebApi.Repository.Repositories
{
    public partial class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        public EntityContext Context { get; set; }

        protected DbSet<TEntity> Entity;

        public Repository(EntityContext context)
        {
            Context = context;
            Entity = Context.Set<TEntity>();
        }
    }
}