using LojaQualquer.WebApi.Domain.Interfaces.Services;
using LojaQualquer.WebApi.Domain.Models.Request;
using LojaQualquer.WebApi.Domain.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{productId}")]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(400, Type = typeof(ResponseError))]
        [ProducesResponseType(500, Type = typeof(ResponseError))]
        public async Task<IActionResult> Put(int productId, [FromBody] ProductCreateUpdateRequest request)
        {
            await _productService.PutAsync(productId, request);
            return Ok();
        }

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpDelete("{productId}")]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(400, Type = typeof(ResponseError))]
        [ProducesResponseType(500, Type = typeof(ResponseError))]
        public async Task<IActionResult> Delete(int productId)
        {
            await _productService.DeleteAsync(productId);
            return Ok();
        }

        /// <summary>
        /// Get products by filter
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(IList<ProductResponse>))]
        [ProducesResponseType(400, Type = typeof(ResponseError))]
        [ProducesResponseType(500, Type = typeof(ResponseError))]
        public async Task<IActionResult> GetByAll([FromQuery] ProductFilterRequest request)
        {
            return Ok(await _productService.GetByFilterAsync(request));
        }
    }
}
