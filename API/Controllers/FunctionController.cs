﻿using API.Helper;
using API.IRepository;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("api/chuc_nang")]
    public class FunctionController : ControllerBase
    {
        private readonly ILogger<FunctionController> _logger;
        private readonly IConfiguration configuration;
        private readonly IFunctionRepository _funcRepo;
        public FunctionController(ILogger<FunctionController> logger, IConfiguration iConfig, IFunctionRepository funcRepo)
        {
            _logger = logger;
            configuration = iConfig;
            _funcRepo = funcRepo;
        }

        [HttpPost]
        [Route("get_menu")]
        public ResultAPI get_menu(Account account)
        {
            List<Function> TreeviewCategory = new List<Function>();
            List<Function> data = new List<Function>();
            ResultAPI info = new ResultAPI();
            data = _funcRepo.Get_Menu(account.Company);//Lấy tất cả menu
            if (data.Count > 1)
            {
                data = data.Where(x => x.MenuChild == null || x.MenuChild == "" || x.MenuChild == String.Empty).ToList(); // lấy tất cả menu có MenuChild = null
                foreach (var item in data)
                {
                    var idcurrent = item.MenuId;//lấy menu và bắt đầu chạy for để tìm menu con
                    List<Function> func = DequiMenu(idcurrent, account.Company); // Chạy đệ quy 
                    item.SubMenu = func;
                    TreeviewCategory.Add(item);
                }
                info.Data = TreeviewCategory;
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
        [HttpGet]
        [Route("dequi")]
        public List<Function> DequiMenu(string idcurrent, string code)
        {
            List<Function> TreeviewCategory = new List<Function>();
            var datachild = _funcRepo.Get_Menu(code).Where(o => o.MenuChild == idcurrent).ToList();

            if (datachild.Count > 0)
            {
                foreach (var itemchild in datachild)
                {
                    itemchild.Title = itemchild.Title;
                    TreeviewCategory.Add(itemchild);
                    DequiMenu(itemchild.MenuId, code);
                }
            }
            return TreeviewCategory;
        }
    }
}
