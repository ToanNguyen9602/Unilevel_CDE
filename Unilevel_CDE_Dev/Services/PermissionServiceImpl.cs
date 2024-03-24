using Unilevel_CDE_Dev.Controllers;
using Unilevel_CDE_Dev.Models;

namespace Unilevel_CDE_Dev.Services
{
    public class PermissionServiceImpl : PermissionService
    {
        private DatabaseContext db;

        public PermissionServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }

        public bool Create(Permission permission )
        {
            try
            {
                db.Permissions.Add(permission);
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Permission permission)
        {
            try
            {
                db.Permissions.Remove(permission);
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public dynamic findAll()
        {
            return db.Permissions.Select(p => new
            {
                Id = p.Id,
                Name = p.Name,
            }).ToList();
        }

        public dynamic FindId(int id)
        {
            return db.Permissions.Where(p => p.Id == id).Select(p => new
            {
                Id = p.Id,
                Name = p.Name,
            }).FirstOrDefault();
        }

        public bool Update(Permission permission)
        {
            try
            {
                db.Entry(permission).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
