using Book_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Data.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        //Van la interface nen ko can dinh nghia cac phuong thuc trong IRepository
        void Update(Category category);
    }
}
