using System;

namespace API.Models
{
    public class Account
    {
        private string _id;
        private string _company;
        private string _userName;
        private string _password;
        private string _fullName;
        private string _avatar;
        private string _roleId;
        private DateTime _createDate;
        private DateTime _modifyDate;
        private DateTime _birthDate;
        private string _address;
        private string _phone;
        private int _status;
        private string _country;
        private string _email;

        public string Id { get => _id; set => _id = value; }
        public string UserName { get => _userName; set => _userName = value; }
        public string Password { get => _password; set => _password = value; }
        public string FullName { get => _fullName; set => _fullName = value; }
        public string Avatar { get => _avatar; set => _avatar = value; }
        public string RoleId { get => _roleId; set => _roleId = value; }
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }
        public DateTime ModifyDate { get => _modifyDate; set => _modifyDate = value; }
        public DateTime BirthDate { get => _birthDate; set => _birthDate = value; }
        public string Address { get => _address; set => _address = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public int Status { get => _status; set => _status = value; }
        public string Country { get => _country; set => _country = value; }
        public string Company { get => _company; set => _company = value; }
        public string Email { get => _email; set => _email = value; }
    }
}
