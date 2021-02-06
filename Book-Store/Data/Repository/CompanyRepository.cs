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
            var updateCompany = _db.Companies.FirstOrDefault(c => c.Id == company.Id);
            if (updateCompany != null)
            {
                updateCompany.Name = company.Name;
                _db.SaveChanges();
            }
        }
    }
}
