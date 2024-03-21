using Unilevel_CDE_Dev.Models;

namespace Unilevel_CDE_Dev.Services
{
    public interface UserList
    {
        public bool Create(UserList userList);
        public dynamic FindId(int id);
        public bool Update(Area area);
        public dynamic findAll();
    }
}
