using Business.Exceptions;
using Business.Services.Abstract;
using Core.Models;
using Core.RepositoryAbstract;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        

        IProductService _productService;
        IWebHostEnvironment _env;

        public ProductController(IProductService productService, IWebHostEnvironment env)

        {
            _productService = productService;
            _env=env;
            
        }
        public IActionResult Index()
        {
            var categories = _productService.GetAll();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
                return View();



            try
            {
                await _productService.AddAsync(product);
            }
            catch (DuplicateCategoryException ex)
            {

                ModelState.AddModelError("Title", ex.Message);
                return View();
            }
            return RedirectToAction("index");

        }


        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            try
            {
                _productService.Delete(id);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex);
            }

            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            var existCategory = _productService.Get(x => x.Id == id);

            if (existCategory == null)
            {
                return NotFound();
            }

            return View(existCategory);
        }


        public IActionResult Update(int id)
        {
            var existCategory = _productService.Get(x => x.Id == id);

            if (existCategory == null) return NotFound();

            return View(existCategory);
        }

        [HttpPost]
        public IActionResult Update(Product newProduct)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                _productService.Update(newProduct.Id, newProduct);
            }
            catch (EntityNotFoundException ex)
            {

                return NotFound();
            }
            catch (DuplicateCategoryException ex)
            {
                ModelState.AddModelError("Title", ex.Message);
                return View();
            }

            return RedirectToAction("index");
        }
    }
}
