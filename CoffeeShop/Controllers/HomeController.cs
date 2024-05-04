using DataAccess.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;
using System.Diagnostics;

namespace CoffeeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public HomeController(ILogger<HomeController> logger,
            IProductRepository productRepository,
            ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index(string? categoryName)
        {
            var products = _productRepository.GetAll();
            var categories = _categoryRepository.GetAll();

            ViewBag.Categories = categories;
            

            if (string.IsNullOrEmpty(categoryName))
            {
                categoryName = categories.FirstOrDefault(c => c.DisplayOrder == 1).CategoryName;
            }

            ViewBag.CategoryName = categoryName;

            if (!string.IsNullOrEmpty(categoryName))
            {
                products = products.Where(p => p.Category.CategoryName == categoryName).ToList();
            }

            return View(products);
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
