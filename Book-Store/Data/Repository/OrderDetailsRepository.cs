using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_Store.Models;
using Book_Store.Data.Repository.IRepository;

namespace Book_Store.Data.Repository
{
    public class OrderDetailsRepository : Repository<OrderDetails>,IOrderDetailsRepository
    {
        private readonly BSContext _db;

        public OrderDetailsRepository(BSContext db) : base(db)
        {
            _db = db;
        }

        public void Update(OrderDetails orderDetails)
        {
            _db.Update(orderDetails);
        }
    }
}
