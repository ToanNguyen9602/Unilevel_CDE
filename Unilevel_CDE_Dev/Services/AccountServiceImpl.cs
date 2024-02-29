using Unilevel_CDE_Dev.Models;

namespace Unilevel_CDE_Dev.Services
{
    public class AccountServiceImpl : AccountService
    {
        private DatabaseContext db;

        public AccountServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }

        public bool Create(Account account)
        {
            try
            {
                db.Accounts.Add(account);
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public dynamic FindId(int id)
        {
            throw new NotImplementedException();
        }

        public bool Login(int id, string password)
        {
            var account = db.Accounts.SingleOrDefault(a => a.Id == id && a.Password.Equals(password));
            if (account != null)
            {
                return BCrypt.Net.BCrypt.Verify(password, account.Password);
            }
            return false;
        }

        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool Update(Account account)
        {
            try
            {

                db.Entry(account).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
