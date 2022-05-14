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
    public class DistrictRepository : IDistrictRepository
    {
        private readonly DapperContext _context;
        public DistrictRepository(DapperContext context)
        {
            _context = context;
        }
        public List<District> Get_All_District(string Company)
        {
            using (var connection = _context.CreateConnection())
            {
                var param = new DynamicParameters();
                param.Add("@pCompany", Company, DbType.String);
                var acc = connection.Query<District>("GetAllDistrict", param, commandType: CommandType.StoredProcedure);
                return acc.ToList();
            }
        }
        public string them_moi(District District)
        {
            var param = new DynamicParameters();
            param.Add("@pId", Guid.NewGuid(), DbType.Guid);
            param.Add("@pCompany", District.Company, DbType.String);
            param.Add("@pCode", District.Code, DbType.String);
            param.Add("@pName", District.Name, DbType.String);
            param.Add("@pLevel", District.Level, DbType.String);
            param.Add("@pStatus", District.Status, DbType.String);
            param.Add("@pUser", District.CreateBy, DbType.String);
            param.Add("@pDatetime", District.CreateDate, DbType.DateTime);
            using (var connection = _context.CreateConnection())
            {
                var Id = connection.Execute("AddDistrict", param, commandType: CommandType.StoredProcedure);
                return Id.ToString();
            }
        }
        public string sua_khach_hang(District District)
        {
            var param = new DynamicParameters();
            param.Add("@pId", District.Id, DbType.String);
            param.Add("@pCompany", District.Company, DbType.String);
            param.Add("@pCode", District.Code, DbType.String);
            param.Add("@pName", District.Name, DbType.String);
            param.Add("@pLevel", District.Level, DbType.String);
            param.Add("@pStatus", District.Status, DbType.String);
            param.Add("@pUser", District.ModifyBy, DbType.String);
            param.Add("@pDatetime", District.ModifyDate, DbType.DateTime);
            using (var connection = _context.CreateConnection())
            {
                var Id = connection.Execute("UpdateDistrict", param, commandType: CommandType.StoredProcedure);
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
                var check = connection.Query("DeleteDistrict", param, commandType: CommandType.StoredProcedure);
                return true;
            }
        }
    }
}
