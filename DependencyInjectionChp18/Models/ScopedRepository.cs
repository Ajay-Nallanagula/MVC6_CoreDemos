using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjectionChp18.Models.InterfaceDi;

namespace DependencyInjectionChp18.Models
{
    public class ScopedRepository : IScopedRepository
    {
        private readonly Dictionary<string, Product> _productsDict;

        public ScopedRepository()
        {
            _productsDict = new Dictionary<string, Product>();
            var listProducts = new List<Product>
            {
                new Product {Name = "Bike", Price = 18M},
                new Product {Name = "Car", Price = 50M},
                new Product {Name = "Aeroplane", Price = 90M}
            };
            listProducts.ForEach(AddProduct);
        }
        public void AddProduct(Product product) => _productsDict.Add(product.Name, product);
        

        public void DeleteProduct(Product product) => _productsDict.Remove(product.Name);

        public override string ToString() => Guid.NewGuid().ToString();
    }
}
