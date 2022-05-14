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
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly DapperContext _context;
        public ProvinceRepository(DapperContext context)
        {
            _context = context;
        }
        public List<Province> Get_All_Province(string Company)
        {
            using (var connection = _context.CreateConnection())
            {
                var param = new DynamicParameters();
                param.Add("@pCompany", Company, DbType.String);
                var acc = connection.Query<Province>("GetAllProvince", param, commandType: CommandType.StoredProcedure);
                return acc.ToList();
            }
        }
        public string them_moi(Province Province)
        {
            var param = new DynamicParameters();
            param.Add("@pId", Guid.NewGuid(), DbType.Guid);
            param.Add("@pCompany", Province.Company, DbType.String);
            param.Add("@pCode", Province.Code, DbType.String);
            param.Add("@pName", Province.Name, DbType.String);
            param.Add("@pLevel", Province.Level, DbType.String);
            param.Add("@pStatus", Province.Status, DbType.String);
            param.Add("@pUser", Province.CreateBy, DbType.String);
            param.Add("@pDatetime", Province.CreateDate, DbType.DateTime);
            using (var connection = _context.CreateConnection())
            {
                var Id = connection.Execute("AddProvince", param, commandType: CommandType.StoredProcedure);
                return Id.ToString();
            }
        }
        public string sua_khach_hang(Province Province)
        {
            var param = new DynamicParameters();
            param.Add("@pId", Province.Id, DbType.String);
            param.Add("@pCompany", Province.Company, DbType.String);
            param.Add("@pCode", Province.Code, DbType.String);
            param.Add("@pName", Province.Name, DbType.String);
            param.Add("@pLevel", Province.Level, DbType.String);
            param.Add("@pStatus", Province.Status, DbType.String);
            param.Add("@pUser", Province.ModifyBy, DbType.String);
            param.Add("@pDatetime", Province.ModifyDate, DbType.DateTime);
            using (var connection = _context.CreateConnection())
            {
                var Id = connection.Execute("UpdateProvince", param, commandType: CommandType.StoredProcedure);
                return Id.ToString();
            }
        }
        public bool xoa_khach_hang(string Id, string Company)
        {
            var param = new DynamicParameters();
            param.Add("@pCompany", Company, DbType.String);
            param.Add("@pId", Id, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                var check = connection.Query("DeleteProvince", param, commandType: CommandType.StoredProcedure);
                return true;
            }
        }
    }
}
