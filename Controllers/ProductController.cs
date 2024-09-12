using Microsoft.AspNetCore.Mvc;
using manage_product_service.Models;
using manage_product_service.Services;

namespace manage_product_service.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getallproducts")]
        public IActionResult GetAllProducts()
        {
            return Ok(_productService.GetAllProducts());
        }

        [HttpPost("addproduct")]
        public IActionResult AddProduct(ProductCreateModel productCreateModel)
        {
            // linking the new product model with the product
            var product = new Product
            {
                Name = productCreateModel.Name,
                Price = productCreateModel.Price,
                StockQuantity = productCreateModel.StockQuantity
            };
            //adding the new product
            var createdProduct = _productService.AddProduct(product);
            return Ok(createdProduct);
        }

        [HttpPut("updateproduct")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            var updatedProduct = _productService.UpdateProduct(id, product);
            if (updatedProduct == null) return NotFound();
            return Ok(updatedProduct);
        }
    }
}
