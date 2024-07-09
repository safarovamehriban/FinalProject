using Business.Extentions;
using Business.Services.Abstract;
using Core.Models;
using Core.RepositoryAbstract;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concretes
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _poroductRepository;
        private readonly IWebHostEnvironment _env;

        public ProductService(IProductRepository productRepository, IWebHostEnvironment env)
        {
            _env = env;
            _poroductRepository = productRepository;
        }


        public async Task AddAsync(Product product)
        {

            product.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads", product.ImageFile);
            
            await _poroductRepository.AddAsync(product);
            await _poroductRepository.CommitAsync();
        }

        public void Delete(int id)
        {
            var existProduct = _poroductRepository.Get(x => x.Id == id);
            if (existProduct == null) throw new NullReferenceException();

            _poroductRepository.Delete(existProduct);
            _poroductRepository.Commit();
        }

        public Product Get(Func<Product, bool>? func = null)
        {
            return _poroductRepository.Get(func);
        }

        public List<Product> GetAll(Func<Product, bool>? func = null)
        {
            return _poroductRepository.GetAll(func);
        }

        public void Update(int id, Product newProduct)
        {
            Product oldProduct = _poroductRepository.Get(x => x.Id == id);
            if (oldProduct == null) throw new NullReferenceException();


            oldProduct.Title = newProduct.Title;
            oldProduct.Description = newProduct.Description;
            oldProduct.ImageUrl = newProduct.ImageUrl;
            oldProduct.ImageFile = newProduct.ImageFile;


            _poroductRepository.Commit();
        }
    }
}
