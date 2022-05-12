using System;

namespace API.Models
{
    public class ResultAPI
    {
        public string Message { get; set; }
        public object Data { get; set; }
        public int Code { get; set; }
    }
}
