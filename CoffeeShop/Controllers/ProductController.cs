using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ShopContext _shopContext;

        public ProductController(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public ActionResult Index()
        {
            List<Product> products = _shopContext.Products.Include(p => p.Category).ToList();

            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _shopContext.Products.Add(product);
                _shopContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(Guid? productId)
        {
            if (productId == null)
            {
                return BadRequest();
            }

            var product = _shopContext.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _shopContext.Products.Update(product);
                _shopContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(Guid? productId)
        {
            if (productId == null)
            {
                return BadRequest();
            }

            var product = _shopContext.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == productId);
            if (productId == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(Guid? productId)
        {
            var product = _shopContext.Products.Find(productId);
            if (productId == null)
            {
                return NotFound();
            }

            _shopContext.Products.Remove(product);
            _shopContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
