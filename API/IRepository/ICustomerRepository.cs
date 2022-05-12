using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.IRepository
{
    public interface ICustomerRepository
    {
        public List<Customer> Get_All_Customer(string Code);
        public string them_moi(Customer Customer);
        public string sua_khach_hang(Customer Customer);
        public bool xoa_khach_hang(string Id, string Code);
    }
}
