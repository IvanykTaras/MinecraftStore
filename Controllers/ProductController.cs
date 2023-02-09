using Microsoft.AspNetCore.Mvc;
using MinecraftStore.Data;
using MinecraftStore.Data.Service;
using MinecraftStore.Models;
using Newtonsoft;
using Newtonsoft.Json;
using System.Text;

namespace MinecraftStore.Controllers
{
    public class ProductController : Controller
    {
        Uri baseAddres = new Uri("https://localhost:7069/api/products");
        HttpClient client;
        private readonly IProductService<Product> _productService;
        public ProductController(IProductService<Product> productService)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddres;

            _productService = productService;
        }




        public IActionResult Index()
        {
            List<Product> productList = new List<Product>();

            HttpResponseMessage responseMessage = client.GetAsync(client.BaseAddress).Result;
            if (responseMessage.IsSuccessStatusCode) {
                string data = responseMessage.Content.ReadAsStringAsync().Result;
                productList = JsonConvert.DeserializeObject<List<Product>>(data);
            }

            return View(productList);
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
            if (ModelState.IsValid)
            {
                string data = JsonConvert.SerializeObject(product);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage responseMessage = client.PostAsync(client.BaseAddress, content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

           
            return View(product);
        }

        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product findProduct = new Product();

            HttpResponseMessage responseMessage = client.GetAsync(client.BaseAddress + $"/{id}").Result;
            if (responseMessage.IsSuccessStatusCode) {
                string data = responseMessage.Content.ReadAsStringAsync().Result;
                findProduct = JsonConvert.DeserializeObject<Product>(data);
            }

            return View(findProduct);
        }

        [HttpPost]
        public IActionResult Edit(Product findProduct)
        {
            string data = JsonConvert.SerializeObject(findProduct);
            StringContent content = new StringContent(data, Encoding.UTF8,"application/json");
            HttpResponseMessage responseMessage = client.PutAsync(client.BaseAddress, content ).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(findProduct);
        }


        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage responseMessage = client.DeleteAsync(client.BaseAddress + $"/{id}" ).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                string data =  responseMessage.Content.ReadAsStringAsync().Result;
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Create)); ;
            //_productService.Delete(id);

        }
    }
}
