using System;

namespace API.Models
{
    public class Customer : Common
    {
        private string _id;
        private string _ma_khach_hang;
        private string _ten_khach_hang;
        private string _dia_chi;
        private string _dien_thoai;
        private string _email;

        public string Id { get => _id; set => _id = value; }
        public string Ma_khach_hang { get => _ma_khach_hang; set => _ma_khach_hang = value; }
        public string Ten_khach_hang { get => _ten_khach_hang; set => _ten_khach_hang = value; }
        public string Dia_chi { get => _dia_chi; set => _dia_chi = value; }
        public string Dien_thoai { get => _dien_thoai; set => _dien_thoai = value; }
        public string Email { get => _email; set => _email = value; }
    }
}
