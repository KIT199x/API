using API.Common;
using API.IRepository;
using API.Models;
using Microsoft.AspNetCore.Http;
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
    [Route("api/khach_hang")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IConfiguration configuration;
        private readonly ICustomerRepository _funcRepo;
        public CustomerController(ILogger<CustomerController> logger, IConfiguration iConfig, ICustomerRepository funcRepo)
        {
            _logger = logger;
            configuration = iConfig;
            _funcRepo = funcRepo;
        }

        [HttpGet]
        [Route("get_khach_hang")]
        public ResultAPI get_khach_hang(string Code)
        {
            List<Customer> customers = new List<Customer>();
            ResultAPI info = new ResultAPI();
            customers = _funcRepo.Get_All_Customer(Code);//Lấy tất cả khách hàng
            if (customers.Count > 0)
            {
                info.Data = customers;
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
        public ResultAPI them_moi([FromBody] Customer customer)
        {
            ResultAPI info = new ResultAPI();
            var rst = _funcRepo.them_moi(customer);
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
        public ResultAPI sua_khach_hang([FromBody] Customer customer)
        {
            ResultAPI info = new ResultAPI();
            var rst = _funcRepo.sua_khach_hang(customer);
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
        public ResultAPI xoa_khach_hang(string Id, string Code)
        {
            ResultAPI info = new ResultAPI();
            var rst = _funcRepo.xoa_khach_hang(Id, Code);
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
        public ResultAPI Import( JsonResult dataJson)
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
