using DataAccess;
using DataAccess.Models;
using DataAccess.ViewModels;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopContext _shopContext;

        public ProductRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public void Add(ProductViewModel productVM)
        {
            Product product = new Product
            {
                ProductName = productVM.ProductName,
                Price = productVM.Price,
                Description = productVM.Description,
                DisplayOrder = productVM.DisplayOrder,
                ImageUrl = productVM.ImageUrl,
                CategoryId = productVM.CategoryId
            };

            _shopContext.Products.Add(product);
            _shopContext.SaveChanges();
        }

        public void Delete(Guid? id)
        {
            Product? product = _shopContext.Products.Find(id);

            _shopContext.Products.Remove(product);
            _shopContext.SaveChanges();
        }

        public List<ProductViewModel> GetAll()
        {
            List<Product> products = _shopContext.Products.Include(p => p.Category).ToList();

            return products.Select(p => new ProductViewModel
            {
                Id = p.Id,
                ProductName = p.ProductName,
                Price = p.Price,
                Description = p.Description,
                DisplayOrder = p.DisplayOrder,
                ImageUrl = p.ImageUrl,
                CategoryId = p.CategoryId,
                Category = new CategoryViewModel
                {
                    Id = p.Category.Id,
                    CategoryName = p.Category.CategoryName,
                    DisplayOrder = p.Category.DisplayOrder
                }
            }).ToList();
        }

        public ProductViewModel GetById(Guid? id)
        {
            if (id == null)
            {
                throw new Exception(message: "Product Id == null");
            }

            Product? product = _shopContext.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new Exception(message: "Product is null");
            }

            return new ProductViewModel
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                Description = product.Description,
                DisplayOrder = product.DisplayOrder,
                ImageUrl = product.ImageUrl,
                CategoryId = product.CategoryId,
                Category = new CategoryViewModel
                {
                    Id = product.Category.Id,
                    CategoryName = product.Category.CategoryName,
                    DisplayOrder = product.DisplayOrder
                }
            };
        }

        public void Update(ProductViewModel productVM)
        {
            Product product = new Product
            {
                Id = productVM.Id,
                ProductName = productVM.ProductName,
                Price = productVM.Price,
                Description = productVM.Description,
                DisplayOrder = productVM.DisplayOrder,
                ImageUrl = productVM.ImageUrl,
                CategoryId = productVM.CategoryId
            };

            _shopContext.Products.Update(product);
            _shopContext.SaveChanges();
        }
    }
}
