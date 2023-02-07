using Microsoft.AspNetCore.Mvc;
using MinecraftStore.Data;
using MinecraftStore.Data.Service;
using MinecraftStore.Models;

namespace MinecraftStore.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService<Product> _productService;
        public ProductController(IProductService<Product> productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {

            return View(_productService.FindAll());
        }


        [HttpGet]
        public IActionResult Create()
        {
            Product product = new Product();
            return View(product);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {

            if (ModelState.IsValid) {
                _productService.Save(product);


                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var findProduct = _productService.FindById(id);
            return View(findProduct);
        }

        [HttpPost]
        public IActionResult Edit(Product findProduct)
        {
            _productService.Update(findProduct);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id)
        {
            _productService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
