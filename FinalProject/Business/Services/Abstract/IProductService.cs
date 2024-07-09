using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
    public interface IProductService
    {
        Task AddAsync(Product product);
        void Delete(int id);
        void Update(int id, Product newProduct);
        Product Get(Func<Product, bool>? func = null);
        List<Product> GetAll(Func<Product, bool>? func = null);
    }
}
