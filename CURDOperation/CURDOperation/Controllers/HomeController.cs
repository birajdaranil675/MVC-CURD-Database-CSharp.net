using CURDOperation.DBContext;
using CURDOperation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CURDOperation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductDBContext _productContext;

        public HomeController(ILogger<HomeController> logger, ProductDBContext productContext)
        {
            _logger = logger;
            _productContext = productContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetData() 
        {
            ProductDetails productDetails = new ProductDetails();
            productDetails.productsList = new List<Product>();
            var data = _productContext.Products.ToList();

            foreach (var product in data) 
            {
                productDetails.productsList.Add(product);
            }
            return View(productDetails);
        }

        [HttpGet]
        public IActionResult AddProduct() 
        {
            return View();
        }

        [HttpPost]
        public string AddProduct(Product product)
        {
            try
            {
                var Input = new Product()
                {
                    //Id= product.Id,
                    Name= product.Name,
                    Description= product.Description,   
                    Price= product.Price,
                };
                _productContext.Products.Add(Input);
                _productContext.SaveChanges();
            }
            catch(Exception ex)
            {

            }

            return "Data added sucessfully...";
            
            //return View("GetData","Home");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id) 
        {
            var data = _productContext.Products.FirstOrDefault(p => p.Id == id);

            return View(data);
        }
        
        [HttpPost]
        public string UpdateProduct(Product product) 
        {
            var data = _productContext.Products.FirstOrDefault(p => p.Name == product.Name);

            data.Name = product.Name; 
            data.Description = product.Description;
            data.Price = product.Price;

            _productContext.SaveChanges();

            return "Sucessfully updated...";
        }

        [HttpGet]
        public string DeleteProduct(int id) 
        {
            var data = _productContext.Products.FirstOrDefault(p=>p.Id == id);
            _productContext.Products.Remove(data);
            _productContext.SaveChanges();

            return "product removed....";
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}