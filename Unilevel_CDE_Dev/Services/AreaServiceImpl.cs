using Unilevel_CDE_Dev.Models;

namespace Unilevel_CDE_Dev.Services
{
    public class AreaServiceImpl : AreaService
    {
        private DatabaseContext db;

        public AreaServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }

        public bool Create(Area area)
        {
            try
            {
                db.Areas.Add(area);
                return db.SaveChanges() > 0;
            } catch
            {
                return false;
            }
            
        }
        public bool Update(Area area)
        {
            try
            {

                db.Entry(area).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public dynamic FindId(int id)
        {
            return db.Areas.Where(a => a.Id == id).Select(a => new
            {
                Id = a.Id,
                Area_Code = a.AreaCode,
                Area = a.Area1
            }).FirstOrDefault();
        }

        public dynamic findAll()
        {
            return db.Accounts.Select(a => new
            {
                Id = a.Id,
                AreaCode = a.Area.AreaCode,
                Area1 = a.Area.Area1
            }).ToList();
        }
    }
}
