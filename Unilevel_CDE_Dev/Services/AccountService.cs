using Unilevel_CDE_Dev.Models;

namespace Unilevel_CDE_Dev.Services
{
    public interface AccountService
    {
        public bool Create(Account Account);
        public dynamic FindId(int id);
        public bool Login(int id, string password);
        public bool Update(Account account);
        public dynamic findAll();
    }
}
