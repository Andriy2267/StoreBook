using StoreBook.Data;
using StoreBook.Models;
using StoreBook.Repository.IRepository;
namespace StoreBook.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }
    }
}
