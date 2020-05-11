using Microsoft.AspNetCore.Mvc;
using Practice.Models;
using Practice.Services;
using Practice.WebApp.Models;

namespace Practice.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet]
        public IActionResult List()
        {
            var viewModel = new ProductListViewModel
            {
                Products = _productService.GetProducts()
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult @New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            var result = _productService.AddProduct(product);

            if (!result)
                return Redirect("/");
                
            return RedirectToAction(nameof(List));
        }

        [HttpGet("/Product/Detail/{id}")]
        public IActionResult Detail(int id)
        {
            var product = _productService.GetProduct(id);

            if (product == default(Product))
                return RedirectToAction(nameof(List));
            
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            var result = _productService.UpdateProduct(product);

            if (!result)
                return Redirect("/");
                
            return RedirectToAction(nameof(List));
        }
    }
}