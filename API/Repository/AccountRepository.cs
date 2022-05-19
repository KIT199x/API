using API.Helper;
using API.IRepository;
using API.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace API.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DapperContext _context;
        public AccountRepository(DapperContext context)
        {
            _context = context;
        }
        public List<Account> GetAllAccount()
        {
            using (var connection = _context.CreateConnection())
            {
                var acc = connection.Query<Account>("GetAllAccount", null, commandType: CommandType.StoredProcedure);
                return acc.ToList();
            }
        }
        public List<Account> Login(string Company, string UserName, string Password)
        {
            var param = new DynamicParameters();
            param.Add("@pCompany", Company, DbType.String);
            param.Add("@pUserName", UserName, DbType.String);
            param.Add("@pPassword", Password, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                var companies = connection.Query<Account>("Login", param, commandType: CommandType.StoredProcedure);
                return companies.ToList();
            }
        }
        public Account AddAccount(Account account)
        {
            var param = new DynamicParameters();
            param.Add("@pId", Guid.NewGuid().ToString().ToLower(), DbType.String);
            param.Add("@pCompany", account.Company, DbType.String);
            param.Add("@pAddress", account.Address, DbType.String);
            param.Add("@pAvatar", account.Avatar, DbType.String);
            param.Add("@pBirthDate", account.BirthDate.ToString()== "1/1/0001 12:00:00 AM"?null:account.BirthDate, DbType.DateTime);
            param.Add("@pEmail", account.Email, DbType.String);
            param.Add("@pFullName", account.FullName, DbType.String);
            param.Add("@pUserName", account.UserName, DbType.String);
            param.Add("@pPassword", account.Password, DbType.String);
            param.Add("@pPhone", account.Phone, DbType.String);
            param.Add("@pRoleId", account.RoleId, DbType.Guid);
            param.Add("@pCreateDate", DateTime.Now.ToString(), DbType.DateTime);
            param.Add("@pStatus", account.Status, DbType.Boolean);
            using (var connection = _context.CreateConnection())
            {
                var id = connection.Query<string>("AddAccount", param, commandType: CommandType.StoredProcedure);
                var createdAccount = new Account
                {
                    //AccountId = account.AccountId,
                    //Email = account.Email,
                    //FullName = account.FullName,
                    //Password = account.Password,
                    //Avatar = account.Avatar
                };
                return createdAccount;
            }
        }
        public Account UpdateAccount(Account account)
        {
            var param = new DynamicParameters();
            //param.Add("@AccountId", account.AccountId, DbType.Guid);
            //param.Add("@Address", account.Address, DbType.String);
            //param.Add("@Avatar", account.Avatar, DbType.String);
            //param.Add("@BirthDate", account.BirthDate, DbType.DateTime);
            //param.Add("@Card", account.Card, DbType.String);
            //param.Add("@Email", account.Email, DbType.String);
            //param.Add("@FullName", account.FullName, DbType.String);
            //param.Add("@Password", account.Password, DbType.String);
            //param.Add("@Phone", account.Phone, DbType.String);
            //param.Add("@RoleId", account.RoleId, DbType.Guid);
            //param.Add("@CreateDate", account.CreateDate, DbType.DateTime);
            //param.Add("@ModifyDate", account.ModifyDate, DbType.DateTime);
            //param.Add("@Status", account.Status, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var id = connection.Query<int>("UpdateAccount", param, commandType: CommandType.StoredProcedure);
                var createdAccount = new Account
                {
                    //AccountId = account.AccountId,
                    //Email = account.Email,
                    //FullName = account.FullName,
                    //Password = account.Password,
                    //Avatar = account.Avatar
                };
                return createdAccount;
            }
        }
        public bool DeleteAccount(Guid AccountId)
        {
            var param = new DynamicParameters();
            param.Add("@AccountId", AccountId, DbType.Guid);
            using (var connection = _context.CreateConnection())
            {
                var check = connection.Query("DeleteAccount", param, commandType: CommandType.StoredProcedure);                
                return true;
            }
        }
    }
}
