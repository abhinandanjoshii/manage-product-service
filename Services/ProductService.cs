using manage_product_service.Models;
using System.Collections.Generic;
using System.Linq;

namespace manage_product_service.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products = new List<Product>();
        private int _nextProductId = 1;
        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }
        public Product GetProductById(int productId)
        {
            return _products.FirstOrDefault(p => p.ProductId == productId);
        }

        public Product AddProduct(Product product)
        {
            product.ProductId = _nextProductId++;
            _products.Add(product);
            return product;
        }

        public Product UpdateProduct(int productId, Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.ProductId == productId);
            if (existingProduct == null) return null;

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.StockQuantity = product.StockQuantity;

            return existingProduct;
        }
    }
}
