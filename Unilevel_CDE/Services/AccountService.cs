using Domain.Entities;

namespace Demo.Services
{
    public interface AccountService
    {
        public bool Create(Account account);
        public bool Login(int id, string password);
        public bool Update(Account account);
        public dynamic FindId(int id);
    }
}
