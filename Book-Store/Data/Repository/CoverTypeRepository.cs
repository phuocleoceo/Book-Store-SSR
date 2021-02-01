using System.Linq;
using Book_Store.Data.Repository.IRepository;
using Book_Store.Models;

namespace Book_Store.Data.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private readonly BSContext _db;

        public CoverTypeRepository(BSContext db) : base(db)
        {
            _db = db;
        }

        public void Update(CoverType coverType)
        {
            var updateCT = _db.Categories.FirstOrDefault(c => c.Id == coverType.Id);
            if (updateCT != null)
            {
                updateCT.Name = coverType.Name;
                _db.SaveChanges();
            }
        }
    }
}
