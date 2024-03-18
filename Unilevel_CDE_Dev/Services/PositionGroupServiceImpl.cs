using Unilevel_CDE_Dev.Models;

namespace Unilevel_CDE_Dev.Services
{
    public class PositionGroupServiceImpl : PositionGroupService
    {
        private DatabaseContext db;
        public PositionGroupServiceImpl(DatabaseContext _db) 
        {
            this.db = _db;
        }
        public bool Create(PositionGroup positionGroup)
        {
            try
            {
                db.PositionGroups.Add(positionGroup);
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public dynamic findAll()
        {
            return db.PositionGroups.Select(p => new
            {
                Id = p.Id,
                Name = p.Name,
            }).ToList();
        }

        public dynamic FindId(int id)
        {
            return db.PositionGroups.Where(p => p.Id == id).Select(p => new
            {
                Id = p.Id,
                Name = p.Name,
            }).FirstOrDefault();
        }

        public bool Update(PositionGroup positionGroup)
        {
            try
            {
                db.Entry(positionGroup).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
