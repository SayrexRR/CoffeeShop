using DataAccess.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;

namespace CoffeeShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            List<CategoryViewModel> categories = _categoryRepository.GetAll();

            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Add(category);

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

            var category = _categoryRepository.GetById(categoryId);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Update(category);

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

            var category = _categoryRepository.GetById(categoryId);
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
            _categoryRepository.Delete(categoryId);

            return RedirectToAction("Index");
        }
    }
}
