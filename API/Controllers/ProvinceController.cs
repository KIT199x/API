using API.Common;
using API.IRepository;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [ApiController]
    [Route("api/tinh_thanhpho")]
    public class ProvinceController : ControllerBase
    {
        private readonly ILogger<ProvinceController> _logger;
        private readonly IConfiguration configuration;
        private readonly IProvinceRepository _funcRepo;
        public ProvinceController(ILogger<ProvinceController> logger, IConfiguration iConfig, IProvinceRepository funcRepo)
        {
            _logger = logger;
            configuration = iConfig;
            _funcRepo = funcRepo;
        }

        [HttpGet]
        [Route("get_tinh_thanhpho")]
        public ResultAPI tinh_thanhpho(string Company)
        {
            List<Province> Provinces = new List<Province>();
            ResultAPI info = new ResultAPI();
            Provinces = _funcRepo.Get_All_Province(Company);//Lấy tất cả tỉnh thành phố
            if (Provinces.Count > 0)
            {
                info.Data = Provinces;
                info.Message = Constant.DataSuccess;
                info.Code = "200";
                return info;
            }
            else
            {
                info.Data = null;
                info.Message = Constant.DataError;
                info.Code = "201";
                return info;
            }
        }
        [HttpPost]
        [Route("them_moi")]
        public ResultAPI them_moi([FromBody] Province Province)
        {
            ResultAPI info = new ResultAPI();
            var rst = _funcRepo.them_moi(Province);
            if (rst != "")
            {
                info.Data = rst;
                info.Message = "Thêm mới thành công";
                info.Code = "200";
                return info;
            }
            else
            {
                info.Data = "";
                info.Message = "Thêm mới thất bại";
                info.Code = "201";
                return info;
            }
        }
        [HttpPut]
        [Route("sua_khach_hang")]
        public ResultAPI sua_khach_hang([FromBody] Province Province)
        {
            ResultAPI info = new ResultAPI();
            var rst = _funcRepo.sua_khach_hang(Province);
            if (rst != "")
            {
                info.Data = rst;
                info.Message = "Sửa khách hàng thành công";
                info.Code = "200";
                return info;
            }
            else
            {
                info.Data = "";
                info.Message = "Sửa khách hàng thất bại";
                info.Code = "201";
                return info;
            }
        }
        [HttpDelete]
        [Route("xoa_khach_hang")]
        public ResultAPI xoa_khach_hang(string Id, string Company)
        {
            ResultAPI info = new ResultAPI();
            var rst = _funcRepo.xoa_khach_hang(Id, Company);
            if (rst == true)
            {
                info.Data = rst;
                info.Message = "Xóa khách hàng thành công";
                info.Code = "200";
                return info;
            }
            else
            {
                info.Data = "";
                info.Message = "Xóa khách hàng thất bại";
                info.Code = "201";
                return info;
            }
        }
        [HttpPost]
        [Route("Import")]
        public ResultAPI Import(JsonResult dataJson)
        {
            ResultAPI info = new ResultAPI();
            bool rst = false;
            if (rst == true)
            {
                info.Data = rst;
                info.Message = "Import khách hàng thành công";
                info.Code = "200";
                return info;
            }
            else
            {
                info.Data = "";
                info.Message = "Import khách hàng thất bại";
                info.Code = "201";
                return info;
            }
        }
    }
}
