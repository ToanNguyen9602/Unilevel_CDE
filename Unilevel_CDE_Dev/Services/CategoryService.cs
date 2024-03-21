using Unilevel_CDE_Dev.Models;

namespace Unilevel_CDE_Dev.Services
{
    public interface CategoryService
    {
        public bool Create(Category category);
        public dynamic FindId(int id);
        public bool Update(Category category);
        public dynamic findAll();
        public bool Delete(Category category);
    }
}
