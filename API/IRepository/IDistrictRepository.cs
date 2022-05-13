using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.IRepository
{
    public interface IDistrictRepository
    {
        public List<District> Get_All_District(string Company);
        public string them_moi(District District);
        public string sua_khach_hang(District District);
        public bool xoa_khach_hang(string Id, string Company);
    }
}
