using StoreBook.Models;
using System.Linq.Expressions;

namespace StoreBook.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
    }
}
