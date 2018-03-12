using System;
using System.Collections.Generic;
using DependencyInjectionChp18.Models.InterfaceDi;

namespace DependencyInjectionChp18.Models
{
    public class MemoryRepository : IRepository
    {
        private readonly Dictionary<string, Product> _productsDict;
        private readonly string guid = Guid.NewGuid().ToString();
        public MemoryRepository()
        {
            _productsDict = new Dictionary<string, Product>();
            var listProducts = new List<Product>
            {
                new Product {Name = "Kayak", Price = 275M},
                new Product {Name = "Lifejacket", Price = 48.95M},
                new Product {Name = "Soccer ball", Price = 19.50M}
            };
            listProducts.ForEach(AddProduct);
        }

        public void AddProduct(Product product) => _productsDict.Add(product.Name, product);
        
        public void DeleteProduct(Product product) => _productsDict.Remove(product.Name);

        public override string ToString() => guid;
    }
}
