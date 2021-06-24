using LojaQualquer.WebApi.Domain.Interfaces.Services;
using LojaQualquer.WebApi.Domain.Models.Request;
using LojaQualquer.WebApi.Domain.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LojaQualquer.WebApi.Controllers
{
    /// <summary>
    /// Product Controller
    /// </summary>
    [Route("api/product")]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productService"></param>
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Create a new product
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(ProductCreateResponse))]
        [ProducesResponseType(400, Type = typeof(ResponseError))]
        [ProducesResponseType(500, Type = typeof(ResponseError))]
        public async Task<IActionResult> Post([FromBody] ProductCreateUpdateRequest request)
        {
            return Ok(await _productService.PostAsync(request));
        }

        /// <summary>
        /// Get a product by id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet("{productId}")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(ProductResponse))]
        [ProducesResponseType(400, Type = typeof(ResponseError))]
        [ProducesResponseType(500, Type = typeof(ResponseError))]
        public async Task<IActionResult> GetById(int productId)
        {
            return Ok(await _productService.GetByIdAsync(productId));
        }
    }
}
