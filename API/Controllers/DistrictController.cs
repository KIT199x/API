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
    [Route("api/danhmucquanhuyen")]
    public class DistrictController : ControllerBase
    {
        private readonly ILogger<DistrictController> _logger;
        private readonly IConfiguration configuration;
        private readonly IDistrictRepository _funcRepo;
        public DistrictController(ILogger<DistrictController> logger, IConfiguration iConfig, IDistrictRepository funcRepo)
        {
            _logger = logger;
            configuration = iConfig;
            _funcRepo = funcRepo;
        }

        [HttpGet]
        [Route("get_danhmucquanhuyen")]
        public ResultAPI tinh_thanhpho(string Company)
        {
            List<District> Districts = new List<District>();
            ResultAPI info = new ResultAPI();
            Districts = _funcRepo.Get_All_District(Company);//Lấy tất cả quận huyện
            if (Districts.Count > 0)
            {
                info.Data = Districts;
                info.Message = Constant.DataSuccess;
                info.Code = Constant.SuccessCode;
                return info;
            }
            else
            {
                info.Data = null;
                info.Message = Constant.DataError;
                info.Code = Constant.ErrorCode;
                return info;
            }
        }
        [HttpPost]
        [Route("them_moi")]
        public ResultAPI them_moi([FromBody] District District)
        {
            ResultAPI info = new ResultAPI();
            var rst = _funcRepo.them_moi(District);
            if (rst != "")
            {
                info.Data = rst;
                info.Message = Constant.AddSuccess;
                info.Code = Constant.SuccessCode;
                return info;
            }
            else
            {
                info.Data = "";
                info.Message = Constant.AddError;
                info.Code = Constant.ErrorCode;
                return info;
            }
        }
        [HttpPut]
        [Route("sua_danhmucquanhuyen")]
        public ResultAPI sua_khach_hang([FromBody] District District)
        {
            ResultAPI info = new ResultAPI();
            var rst = _funcRepo.sua_khach_hang(District);
            if (rst != "")
            {
                info.Data = rst;
                info.Message = Constant.EditSuccess;
                info.Code = Constant.SuccessCode;
                return info;
            }
            else
            {
                info.Data = "";
                info.Message = Constant.EditError;
                info.Code = Constant.ErrorCode;
                return info;
            }
        }
        [HttpDelete]
        [Route("xoa_danhmucquanhuyen")]
        public ResultAPI xoa_khach_hang(string Id, string Company)
        {
            ResultAPI info = new ResultAPI();
            var rst = _funcRepo.xoa_khach_hang(Id, Company);
            if (rst == true)
            {
                info.Data = rst;
                info.Message = Constant.RemoveSuccess;
                info.Code = Constant.SuccessCode;
                return info;
            }
            else
            {
                info.Data = "";
                info.Message = Constant.RemoveError;
                info.Code = Constant.ErrorCode;
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
                info.Message = Constant.ImportSuccess;
                info.Code = Constant.SuccessCode;
                return info;
            }
            else
            {
                info.Data = "";
                info.Message = Constant.ImportError;
                info.Code = Constant.ErrorCode;
                return info;
            }
        }
    }
}
