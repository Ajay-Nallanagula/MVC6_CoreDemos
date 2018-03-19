using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjectionChp18.Models.InterfaceDi;

namespace DependencyInjectionChp18.Models
{
    public class AlternateRepository : IRepository
    {
        private readonly Dictionary<string, Product> _productsDict;
        private readonly string guid = Guid.NewGuid().ToString();
        private List<Product> listProducts;
        public AlternateRepository()
        {
            _productsDict = new Dictionary<string, Product>();
            listProducts = new List<Product>
            {
                new Product {Name = "Bike", Price = 18M},
                new Product {Name = "Car", Price = 50M},
                new Product {Name = "Aeroplane", Price = 90M}
            };
            listProducts.ForEach(AddProduct);
        }

        public void AddProduct(Product product) => _productsDict.Add(product.Name, product);

        public void DeleteProduct(Product product) => _productsDict.Remove(product.Name);

        public override string ToString() => guid;

        public List<Product> FetchProducts() => ProductList;
        public List<Product> ProductList => listProducts;
    }
}
