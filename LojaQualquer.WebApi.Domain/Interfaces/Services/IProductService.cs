using LojaQualquer.WebApi.Domain.Models.Request;
using LojaQualquer.WebApi.Domain.Models.Response;
using System.Threading.Tasks;

namespace LojaQualquer.WebApi.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task<ProductCreateResponse> PostAsync(ProductCreateUpdateRequest request);
    }
}