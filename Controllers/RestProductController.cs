using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinecraftStore.Data.Service;
using MinecraftStore.Models;

namespace MinecraftStore.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class RestProductController : ControllerBase
    {
        private IProductService<Product> _productService;

        public RestProductController(IProductService<Product> serviceProduct)
        {
            _productService = serviceProduct;
        }

        [HttpGet]
        public List<Product> Get() {
            return (List<Product>)_productService.FindAll();
        }


        [HttpGet]
        [Route("{Id}")]
        public Product Get([FromRoute] int? id)
        {
            var find = _productService.FindById(id);
            
            return find;
            
        }

        [HttpPost]
        public ActionResult<Product> Add( Product product)
        {        
            _productService.Save(product);
            return Created($"api/products/{product.Id}", product);
        }


        [HttpPut]
        public Product Put([FromBody] Product product)
        {
            _productService.Update(product);
            return product;
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (_productService.FindById(id) is null)
            {
                return NotFound();
            }
          
            _productService.Delete(id);
            return Ok();
        }
    }
}
