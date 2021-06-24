using LojaQualquer.WebApi.Domain.Entities;
using LojaQualquer.WebApi.Domain.Interfaces.Repositories;
using LojaQualquer.WebApi.Domain.Models.Request;
using LojaQualquer.WebApi.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaQualquer.WebApi.Repository.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(EntityContext context) : base(context) { }

        public async Task<bool> CheckUsedName(string name, int? productId = null)
        {
            return await Entity.AnyAsync(e => e.Name == name && (!productId.HasValue || productId != e.Id));
        }

        public async Task<IList<Product>> GetByFilter(ProductFilterRequest request)
        {
            return await Entity.Where(e =>
                    (string.IsNullOrEmpty(request.Name) || e.Name.Contains(request.Name))
                && (!request.Category.HasValue || e.Category == (CategoryEnum)request.Category))
                .ToListAsync();
        }
    }
}