using LojaQualquer.WebApi.Domain.Models.Request;
using LojaQualquer.WebApi.Domain.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQualquer.WebApi.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task<ProductCreateResponse> PostAsync(ProductCreateUpdateRequest request);
        Task<ProductResponse> GetByIdAsync(int productId);
        Task PutAsync(int productId, ProductCreateUpdateRequest request);
        Task DeleteAsync(int productId);
        Task<IList<ProductResponse>> GetByFilterAsync(ProductFilterRequest request);
    }
}