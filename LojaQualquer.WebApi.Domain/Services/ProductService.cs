using AutoMapper;
using LojaQualquer.WebApi.Domain.Entities;
using LojaQualquer.WebApi.Domain.Interfaces.Repositories;
using LojaQualquer.WebApi.Domain.Interfaces.Services;
using LojaQualquer.WebApi.Domain.Models;
using LojaQualquer.WebApi.Domain.Models.Request;
using LojaQualquer.WebApi.Domain.Models.Response;
using System.Threading.Tasks;

namespace LojaQualquer.WebApi.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductCreateResponse> PostAsync(ProductCreateUpdateRequest request)
        {
            await Validate(request);

            var product = _mapper.Map<Product>(request);

            await _productRepository.InsertAsync(product);
            await _productRepository.SaveChangesAsync();

            return new ProductCreateResponse { ProductId = product.Id };
        }

        public async Task<ProductResponse> GetByIdAsync(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);

            if (product == null) throw new BusinessException("Produto não encontrado.");

            return _mapper.Map<ProductResponse>(product);
        }

        private async Task Validate(ProductCreateUpdateRequest request)
        {
            var checkUsed = await _productRepository.CheckUsedName(request.Name);

            if (checkUsed) 
                throw new BusinessException("Já existe um produto com este nome cadastrado.");
        }
    }
}