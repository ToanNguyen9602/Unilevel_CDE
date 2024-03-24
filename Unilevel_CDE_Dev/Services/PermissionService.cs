using Unilevel_CDE_Dev.Models;

namespace Unilevel_CDE_Dev.Services
{
    public interface PermissionService
    {
        public bool Create(Permission permission);
        public dynamic FindId(int id);
        public bool Update(Permission permission);
        public dynamic findAll();
        public bool Delete(Permission permission);
    }
}
