using System.Linq;
using Book_Store.Data.Repository.IRepository;
using Book_Store.Models;

namespace Book_Store.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly BSContext _db;

        public ProductRepository(BSContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product product)
        {
            var updateProduct = _db.Products.FirstOrDefault(c => c.Id == product.Id);
            if (updateProduct != null)
            {
                if (product.ImageUrl != null)
                {
                    updateProduct.ImageUrl = product.ImageUrl;
                }
                updateProduct.Title = product.Title;
                updateProduct.Description = product.Description;
                updateProduct.ISBN = product.ISBN;
                updateProduct.Author = product.Author;
                updateProduct.ListPrice = product.ListPrice;
                updateProduct.Price = product.Price;
                updateProduct.CategoryId = product.CategoryId;
                updateProduct.CoverTypeId = product.CoverTypeId;

                _db.SaveChanges();
            }
        }
    }
}
