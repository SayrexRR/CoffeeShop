using DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface ICategoryRepository
    {
        List<CategoryViewModel> GetAll();
        void Add(CategoryViewModel categoryVM);
        void Update(CategoryViewModel categoryVM);
        void Delete(Guid? id);
        CategoryViewModel GetById(Guid? id);
    }
}
