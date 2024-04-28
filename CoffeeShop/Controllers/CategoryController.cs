using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ShopContext _shopContext;

        public CategoryController(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public IActionResult Index()
        {
            List<Category> categories = _shopContext.Categories.ToList();

            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _shopContext.Categories.Add(category);
                _shopContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(Guid? categoryId)
        {
            if (categoryId == null)
            {
                return BadRequest();
            }

            var category = _shopContext.Categories.Find(categoryId);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _shopContext.Categories.Update(category);
                _shopContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(Guid? categoryId)
        {
            if (categoryId == null)
            {
                return BadRequest();
            }

            var category = _shopContext.Categories.Find(categoryId);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(Guid? categoryId)
        {
            var category = _shopContext.Categories.Find(categoryId);
            if (category == null)
            {
                return BadRequest();
            }

            _shopContext.Categories.Remove(category);
            _shopContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
