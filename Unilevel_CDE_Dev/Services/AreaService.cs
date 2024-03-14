using Unilevel_CDE_Dev.Models;

namespace Unilevel_CDE_Dev.Services
{
    public interface AreaService
    {
        public bool Create(Area area);
        public dynamic FindId(int id);
        public bool Update(Area area);
        public dynamic findAll();
    }
}
