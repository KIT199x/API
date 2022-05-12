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
    [Route("api/tai_khoan")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IConfiguration configuration;
        private readonly IAccountRepository _accRepo;
        public AccountController(ILogger<AccountController> logger, IConfiguration iConfig, IAccountRepository accRepo)
        {
            _logger = logger;
            configuration = iConfig;
            _accRepo = accRepo;
        }

        [HttpPost]
        [Route("thong_tin_tai_khoan")]
        public Account thong_tin_tai_khoan([FromBody] Account account)
        {
            return account;
        }

        [HttpPost]
        [Route("dang_nhap")]
        public ResultLoginAPI dang_nhap([FromBody] Account account)
        {
            var password = Common.Common.Encrypt(account.Password, configuration.GetSection("MySettings").GetSection("KeyAES").Value, 128);
            account.Password = password;
            List<Account> infologin = new List<Account>();
            ResultLoginAPI info = new ResultLoginAPI();
            infologin = _accRepo.Login(account.Company, account.UserName, account.Password);
            if (infologin.Count == 1)
            {
                info.Data = infologin.FirstOrDefault();
                info.Message = Constant.LoginSuccess;
                info.Code = Constant.SuccessCode;
                info.Token = generateJwtToken(infologin.FirstOrDefault());
                return info;
            }
            else
            {
                info.Data = infologin;
                info.Message = Constant.LoginError;
                info.Code = Constant.ErrorCode;
                return info;
            }
        }
        private string generateJwtToken(Account account)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration.GetSection("MySettings").GetSection("Client_secret").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("UserName", account.UserName.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
