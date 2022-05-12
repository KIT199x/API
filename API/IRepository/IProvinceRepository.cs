using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.IRepository
{
    public interface IProvinceRepository
    {
        public List<Province> Get_All_Province(string Company);
        public string them_moi(Province Province);
        public string sua_khach_hang(Province Province);
        public bool xoa_khach_hang(string Id, string Company);
    }
}
