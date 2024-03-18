using Unilevel_CDE_Dev.Models;

namespace Unilevel_CDE_Dev.Services
{
    public class DistributorServiceImpl : DistributorService
    {
        private DatabaseContext db;

        public DistributorServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }
        public bool Create(Distributor distributor)
        {
            try
            {
                db.Distributors.Add(distributor);
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public dynamic findAll()
        {
            return db.Distributors.Select(d => new
            {
                Id = d.Id,
                Name = d.Name,
                Address = d.Address,
                Email = d.Email,
                Phone = d.Phone,
                AreaId = d.AreaId,
                PositionGroup = d.PositionGroup
            }).ToList();
        }

        public dynamic FindId(int id)
        {
            return db.Distributors.Where(d => d.Id == id).Select(d => new
            {
                Id = d.Id,
                Name = d.Name,
                Address = d.Address,
                Email = d.Email,
                Phone = d.Phone,
                AreaId = d.AreaId,
                PositionGroup = d.PositionGroup
            }).FirstOrDefault();
        }

        public bool Update(Distributor distributor)
        {
            try
            {

                db.Entry(distributor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
