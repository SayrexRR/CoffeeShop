using DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IProductRepository
    {
        List<ProductViewModel> GetAll();
        void Add(ProductViewModel productVM);
        void Update(ProductViewModel productVM);
        void Delete(Guid? id);
        ProductViewModel GetById(Guid? id);
    }
}
