using System;

namespace API.Models
{
    public class District : Common
    {
        private string _id;
        private string _idProvince;
        private string _nameProvince;
        private string _code;
        private string _name;
        private string _level;

        public string Id { get => _id; set => _id = value; }
        public string IdProvince { get => _idProvince; set => _idProvince = value; }
        public string NameProvince { get => _nameProvince; set => _nameProvince = value; }
        public string Code { get => _code; set => _code = value; }
        public string Name { get => _name; set => _name = value; }
        public string Level { get => _level; set => _level = value; }
    }
}
