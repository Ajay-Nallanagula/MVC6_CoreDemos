using System.Collections.Generic;

namespace DependencyInjectionChp18.Models.InterfaceDi
{
    public interface IRepository
    {
        void AddProduct(Product product);
        void DeleteProduct(Product product);
    }
}
