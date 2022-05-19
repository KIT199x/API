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
    public class FunctionRepository : IFunctionRepository
    {
        private readonly DapperContext _context;
        public FunctionRepository(DapperContext context)
        {
            _context = context;
        }
        public List<Function> GetAllFunction()
        {
            using (var connection = _context.CreateConnection())
            {
                var acc = connection.Query<Function>("GetAllFunction", null, commandType: CommandType.StoredProcedure);
                return acc.ToList();
            }
        }
        public List<Function> Get_Menu(string Company)
        {
            using (var connection = _context.CreateConnection())
            {
                var param = new DynamicParameters();
                param.Add("@pCompany", Company, DbType.String);
                var acc = connection.Query<Function>("GetAllMenu", param, commandType: CommandType.StoredProcedure);
                return acc.ToList();
            }
        }
        public List<Function> Login(string Company, string UserName, string Password)
        {
            var param = new DynamicParameters();
            param.Add("@Company", Company, DbType.String);
            param.Add("@UserName", UserName, DbType.String);
            param.Add("@Password", Password, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                var companies = connection.Query<Function>("Login", param, commandType: CommandType.StoredProcedure);
                return companies.ToList();
            }
        }
        public Function AddFunction(Function Function)
        {
            var param = new DynamicParameters();
            //param.Add("@FunctionId", Function.FunctionId, DbType.Guid);
            //param.Add("@Address", Function.Address, DbType.String);
            //param.Add("@Avatar", Function.Avatar, DbType.String);
            //param.Add("@BirthDate", Function.BirthDate, DbType.DateTime);
            //param.Add("@Card", Function.Card, DbType.String);
            //param.Add("@Email", Function.Email, DbType.String);
            //param.Add("@FullName", Function.FullName, DbType.String);
            //param.Add("@Password", Function.Password, DbType.String);
            //param.Add("@Phone", Function.Phone, DbType.String);
            //param.Add("@RoleId", Function.RoleId, DbType.Guid);
            //param.Add("@CreateDate", Function.CreateDate, DbType.DateTime);
            //param.Add("@Status", Function.Status, DbType.Boolean);
            using (var connection = _context.CreateConnection())
            {
                var id = connection.Query<int>("AddFunction", param, commandType: CommandType.StoredProcedure);
                var createdFunction = new Function
                {
                    //FunctionId = Function.FunctionId,
                    //Email = Function.Email,
                    //FullName = Function.FullName,
                    //Password = Function.Password,
                    //Avatar = Function.Avatar
                };
                return createdFunction;
            }
        }
        public Function UpdateFunction(Function Function)
        {
            var param = new DynamicParameters();
            //param.Add("@FunctionId", Function.FunctionId, DbType.Guid);
            //param.Add("@Address", Function.Address, DbType.String);
            //param.Add("@Avatar", Function.Avatar, DbType.String);
            //param.Add("@BirthDate", Function.BirthDate, DbType.DateTime);
            //param.Add("@Card", Function.Card, DbType.String);
            //param.Add("@Email", Function.Email, DbType.String);
            //param.Add("@FullName", Function.FullName, DbType.String);
            //param.Add("@Password", Function.Password, DbType.String);
            //param.Add("@Phone", Function.Phone, DbType.String);
            //param.Add("@RoleId", Function.RoleId, DbType.Guid);
            //param.Add("@CreateDate", Function.CreateDate, DbType.DateTime);
            //param.Add("@ModifyDate", Function.ModifyDate, DbType.DateTime);
            //param.Add("@Status", Function.Status, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var id = connection.Query<int>("UpdateFunction", param, commandType: CommandType.StoredProcedure);
                var createdFunction = new Function
                {
                    //FunctionId = Function.FunctionId,
                    //Email = Function.Email,
                    //FullName = Function.FullName,
                    //Password = Function.Password,
                    //Avatar = Function.Avatar
                };
                return createdFunction;
            }
        }
        public bool DeleteFunction(Guid FunctionId)
        {
            var param = new DynamicParameters();
            param.Add("@FunctionId", FunctionId, DbType.Guid);
            using (var connection = _context.CreateConnection())
            {
                var check = connection.Query("DeleteFunction", param, commandType: CommandType.StoredProcedure);
                return true;
            }
        }
    }
}
