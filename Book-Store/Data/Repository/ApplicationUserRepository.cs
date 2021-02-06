using System.Linq;
using Book_Store.Data.Repository.IRepository;
using Book_Store.Models;

namespace Book_Store.Data.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly BSContext _db;

        public ApplicationUserRepository(BSContext db) : base(db)
        {
            _db = db;
        }
    }
}
