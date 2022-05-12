using System;

namespace API.Models
{
    public class Common
    {
        private string _company;
        private DateTime _createDate;
        private DateTime _modifyDate;
        private string _createBy;
        private string _modifyBy;
        private string _status;

        public string Company { get => _company; set => _company = value; }
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }
        public DateTime ModifyDate { get => _modifyDate; set => _modifyDate = value; }
        public string CreateBy { get => _createBy; set => _createBy = value; }
        public string ModifyBy { get => _modifyBy; set => _modifyBy = value; }
        public string Status { get => _status; set => _status = value; }
    }
}
