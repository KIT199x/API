using EASendMail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace API.Common
{
    public static class Constant 
    {
        #region Message
        public const string LoginSuccess = "Đang nhập thành công";
        public const string LoginError = "Đăng nhập thất bại";
        public const string DataSuccess = "Lấy dữ liệu thành công";
        public const string DataError = "Lấy dữ liệu thất bại";
        public const string AddSuccess = "Thêm dữ liệu thành công";
        public const string AddError = "Thêm dữ liệu thất bại";
        public const string EditSuccess = "Sửa dữ liệu thành công";
        public const string EditError = "Sửa dữ liệu thất bại";
        public const string RemoveSuccess = "Xóa dữ liệu thành công";
        public const string RemoveError = "Xóa dữ liệu thất bại";
        public const string ImportSuccess = "Import dữ liệu thành công";
        public const string ImportError = "Import dữ liệu thất bại";
        public const string ExportSuccess = "Export dữ liệu thành công";
        public const string ExportError = "Export dữ liệu thất bại";
        #endregion

        #region Status
        public const int SuccessCode = 200;
        public const int ErrorCode = 201;
        #endregion
    }
}
