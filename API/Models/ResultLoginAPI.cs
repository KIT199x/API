using System;

namespace API.Models
{
    public class ResultLoginAPI
    {
        public string Message { get; set; }
        public object Data { get; set; }
        public string Code { get; set; }
        public string Token { get; set; }
    }
}
