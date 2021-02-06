using System.Linq;
using Book_Store.Data.Repository.IRepository;
using Book_Store.Models;

namespace Book_Store.Data.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly BSContext _db;

        public CompanyRepository(BSContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Company company)
        {
            _db.Update(company);
        }
    }
}
