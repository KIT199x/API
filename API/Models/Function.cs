using System;

namespace API.Models
{
    public class Function
    {
        private string _menuId;
        private string _href;
        private string _title;
        private string _icon;
        private string _menuChild;
        private string _code;
        private decimal _no;
        private int _status;
        private DateTime _createDate;
        private DateTime _modifyDate;
        private string _createBy;
        private string _modifyBy;
        private object _subMenu;

        public string MenuId { get => _menuId; set => _menuId = value; }
        public string Href { get => _href; set => _href = value; }
        public string Title { get => _title; set => _title = value; }
        public string Icon { get => _icon; set => _icon = value; }
        public string MenuChild { get => _menuChild; set => _menuChild = value; }
        public string Code { get => _code; set => _code = value; }
        public decimal No { get => _no; set => _no = value; }
        public int Status { get => _status; set => _status = value; }
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }
        public DateTime ModifyDate { get => _modifyDate; set => _modifyDate = value; }
        public string CreateBy { get => _createBy; set => _createBy = value; }
        public string ModifyBy { get => _modifyBy; set => _modifyBy = value; }
        public object SubMenu { get => _subMenu; set => _subMenu = value; }
    }
}
