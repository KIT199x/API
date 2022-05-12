using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.IRepository
{
    public interface IFunctionRepository
    {
        public List<Function> GetAllFunction();
        public List<Function> Get_Menu(string Code);
        public Function AddFunction(Function Function);
        public Function UpdateFunction(Function Function);
        public bool DeleteFunction(Guid DeleteFunction);
    }
}
