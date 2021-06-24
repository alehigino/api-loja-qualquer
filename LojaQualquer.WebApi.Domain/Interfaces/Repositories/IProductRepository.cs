using LojaQualquer.WebApi.Domain.Entities;
using LojaQualquer.WebApi.Domain.Models.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQualquer.WebApi.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<bool> CheckUsedName(string name, int? productId = null);
        Task<IList<Product>> GetByFilter(ProductFilterRequest request);
    }
}