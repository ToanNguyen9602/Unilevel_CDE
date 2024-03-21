using System.Security.Principal;
using Unilevel_CDE_Dev.Models;

namespace Unilevel_CDE_Dev.Services
{
    public class CategoryServiceImpl : CategoryService
    {
        private DatabaseContext db;

        public CategoryServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }

        public bool Create(Category category)
        {
            try
            {
                db.Categories.Add(category);
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Category category)
        {
            try
            {
                db.Categories.Remove(category);
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public dynamic findAll()
        {
            return db.Categories.Select(c => new
            {
                Id = c.Id,
                Name = c.Name,
            }).ToList();
        }

        public dynamic FindId(int id)
        {
            return db.Categories.Where(c => c.Id == id).Select(c => new
            {
                Id = c.Id,
                Name = c.Name,
            }).FirstOrDefault();
        }

        public bool Update(Category category)
        {
            try
            {
                db.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
