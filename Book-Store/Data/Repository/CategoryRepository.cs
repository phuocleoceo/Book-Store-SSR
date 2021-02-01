using System.Linq;
using Book_Store.Data.Repository.IRepository;
using Book_Store.Models;

namespace Book_Store.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly BSContext _db;

        public CategoryRepository(BSContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category category)
        {
            var updateCategory = _db.CoverTypes.FirstOrDefault(c => c.Id == category.Id);
            if (updateCategory != null)
            {
                updateCategory.Name = category.Name;
                _db.SaveChanges();
            }
        }
    }
}
