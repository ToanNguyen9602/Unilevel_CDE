﻿using Unilevel_CDE_Dev.Models;

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

        public dynamic findAll()
        {
            return db.Accounts.Select(a => new
            {
                Id = a.Id,
                FullName = a.Fullname,
                Email = a.Email,
                Phone = a.Phone,
                Address = a.Address,
                Photo = a.Photo,
                Description = a.Description,
                Status = a.Status,
                Created = a.Created,
                AreaId = a.Area.Id,
                PositionGroup = a.PositionGroup
            }).ToList();
        }

        public dynamic FindId(int id)
        {
            return db.Accounts.Where(p => p.Id == id).Select(a => new
            {
                Id = a.Id,
                Password = a.Password,
                Fullname = a.Fullname,
                Email = a.Email,
                Phone = a.Phone,
                Address = a.Address,
                Photo = a.Photo,
                Description = a.Description,
                Status = a.Status,
                Created = a.Created,
                AreaId = a.AreaId,
                PositionGroup = a.PositionGroup
            }).FirstOrDefault();
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