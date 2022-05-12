using System;

namespace API.Models
{
    public class Province:Common
    {
        private string _id;
        private string _code;
        private string _name;
        private string _type;

        public string Id { get => _id; set => _id = value; }
        public string Code { get => _code; set => _code = value; }
        public string Name { get => _name; set => _name = value; }
        public string Type { get => _type; set => _type = value; }
    }
}
