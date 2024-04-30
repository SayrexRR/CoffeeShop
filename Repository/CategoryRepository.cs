using DataAccess;
using DataAccess.Models;
using DataAccess.ViewModels;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopContext _shopContext;

        public CategoryRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public void Add(CategoryViewModel categoryVM)
        {
            Category category = new Category
            {
                CategoryName = categoryVM.CategoryName,
                DisplayOrder = categoryVM.DisplayOrder
            };

            _shopContext.Categories.Add(category);
            _shopContext.SaveChanges();
        }

        public void Delete(Guid? id)
        {
            Category? category = _shopContext.Categories.Find(id);

            _shopContext.Categories.Remove(category);
            _shopContext.SaveChanges();
        }

        public List<CategoryViewModel> GetAll()
        {
            var categories = _shopContext.Categories.ToList();

            return categories.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                CategoryName = c.CategoryName,
                DisplayOrder = c.DisplayOrder
            }).ToList();
        }

        public CategoryViewModel GetById(Guid? id)
        {
            if (id == null)
            {
                throw new Exception(message: "Category Id == null");
            }

            Category? category = _shopContext.Categories.Find(id);
            if (category == null)
            {
                throw new Exception(message: "Category is null");
            }

            return new CategoryViewModel
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                DisplayOrder = category.DisplayOrder
            };
        }

        public void Update(CategoryViewModel categoryVM)
        {
            Category category = new Category
            {
                Id = categoryVM.Id,
                CategoryName = categoryVM.CategoryName,
                DisplayOrder = categoryVM.DisplayOrder
            };

            _shopContext.Categories.Update(category);
            _shopContext.SaveChanges();
        }
    }
}
