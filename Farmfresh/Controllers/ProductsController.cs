using AutoMapper;
using Farmfresh.Models;
using Farmfresh.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace Farmfresh.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery(Name ="page")] int pageNumber = 1, [FromQuery(Name ="limit")] int pageSize = 25, [FromQuery(Name ="keyword")] string keyword = null)
        {
            var result = await _productService.GetAll(keyword,pageNumber, pageSize);
            return Ok(result);
        }

        [HttpGet("{product-id}")]
        public async Task<IActionResult> GetProduct([FromRoute(Name ="product-id")] int productId)
        {
            var result = await _productService.GetById(productId);  
            return Ok(result);
        }

        [HttpGet("category/{category-id}")]
        public async Task<IActionResult> GetByCategory([FromRoute(Name ="category-id")] int categoryId, [FromQuery(Name = "page")] int pageNumber = 1, [FromQuery(Name = "limit")] int pageSize = 25)
        {
            var result = await _productService.GetByCategoryId(categoryId, pageNumber, pageSize);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProduct([FromForm] ProductDto product)
        {
            var entity = _mapper.Map<Product>(product);
            var result = await _productService.Add(entity);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(int productId, [FromForm] ProductDto product)
        {
            var entity = _mapper.Map<Product>(product);
            var result = await _productService.Update(productId, entity);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var delete = await _productService.Delete(productId);
            return Ok(delete);
        }
    }


}
