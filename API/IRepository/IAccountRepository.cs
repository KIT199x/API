using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.IRepository
{
    public interface IAccountRepository
    {
        public List<Account> GetAllAccount();
        public List<Account> Login(string Code, string Email, string Password);
        public Account AddAccount(Account account);
        public Account UpdateAccount(Account account);
        public bool DeleteAccount(Guid DeleteAccount);
    }
}
