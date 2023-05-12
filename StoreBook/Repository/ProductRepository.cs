using StoreBook.Models;
using StoreBook.Data;
using StoreBook.Repository.IRepository;

namespace StoreBook.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }
        public void Update(Product product)
        {
            _context.Products.Update(product);
        }
    }
}
