using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionChp18.Models.InterfaceDi
{
    public interface IScopedRepository
    {
        void AddProduct(Product product);
        void DeleteProduct(Product product);
    }
}
