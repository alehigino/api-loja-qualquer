using LojaQualquer.WebApi.Domain.Entities;
using System.Threading.Tasks;

namespace LojaQualquer.WebApi.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<bool> CheckUsedName(string name, int? productId = null);
    }
}