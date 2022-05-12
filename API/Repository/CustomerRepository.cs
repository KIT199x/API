using API.Common;
using API.IRepository;
using API.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace API.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DapperContext _context;
        public CustomerRepository(DapperContext context)
        {
            _context = context;
        }
        public List<Customer> Get_All_Customer(string Company)
        {
            using (var connection = _context.CreateConnection())
            {
                var param = new DynamicParameters();
                param.Add("@pCompany", Company, DbType.String);
                var acc = connection.Query<Customer>("GetAllCustomer", param, commandType: CommandType.StoredProcedure);
                return acc.ToList();
            }
        }
        public string them_moi(Customer Customer)
        {
            var param = new DynamicParameters();
            param.Add("@pId", Guid.NewGuid(), DbType.Guid);
            param.Add("@pCompany", Customer.Company, DbType.String);
            param.Add("@pMa_khach_hang", Customer.Ma_khach_hang, DbType.String);
            param.Add("@pTen_khach_hang", Customer.Ten_khach_hang, DbType.String);
            param.Add("@pDia_chi", Customer.Dia_chi, DbType.String);
            param.Add("@pDien_thoai", Customer.Dien_thoai, DbType.String);
            param.Add("@pEmail", Customer.Email, DbType.String);
            param.Add("@pStatus", Customer.Status, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                var Id = connection.Execute("AddCustomer", param, commandType: CommandType.StoredProcedure);
                return Id.ToString();
            }
        }
        public string sua_khach_hang(Customer Customer)
        {
            var param = new DynamicParameters();
            param.Add("@pId", Customer.Id, DbType.String);
            param.Add("@pCompany", Customer.Company, DbType.String);
            param.Add("@pMa_khach_hang", Customer.Ma_khach_hang, DbType.String);
            param.Add("@pTen_khach_hang", Customer.Ten_khach_hang, DbType.String);
            param.Add("@pDia_chi", Customer.Dia_chi, DbType.String);
            param.Add("@pDien_thoai", Customer.Dien_thoai, DbType.String);
            param.Add("@pEmail", Customer.Email, DbType.String);
            param.Add("@pStatus", Customer.Status, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                var Id = connection.Execute("UpdateCustomer", param, commandType: CommandType.StoredProcedure);
                return Id.ToString();
            }
        }
        public bool xoa_khach_hang(string Id,string Company)
        {
            var param = new DynamicParameters();
            param.Add("@pCompany", Company, DbType.String);
            param.Add("@pId", Id, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                var check = connection.Query("DeleteCustomer", param, commandType: CommandType.StoredProcedure);
                return true;
            }
        }
    }
}
