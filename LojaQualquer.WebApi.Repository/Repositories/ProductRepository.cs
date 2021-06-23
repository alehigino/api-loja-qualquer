using LojaQualquer.WebApi.Domain.Entities;
using LojaQualquer.WebApi.Domain.Interfaces.Repositories;
using LojaQualquer.WebApi.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LojaQualquer.WebApi.Repository.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(EntityContext context) : base(context) { }

        public async Task<bool> CheckUsedName(string name)
        {
            return await Entity.AnyAsync(e => e.Name == name);
        }
    }
}