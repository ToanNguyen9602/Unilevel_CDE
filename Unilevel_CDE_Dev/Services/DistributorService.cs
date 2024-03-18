using Unilevel_CDE_Dev.Models;

namespace Unilevel_CDE_Dev.Services
{
    public interface DistributorService
    {
        public bool Create(Distributor distributor);
        public dynamic FindId(int id);
        public bool Update(Distributor distributor);
        public dynamic findAll();
    }
}
