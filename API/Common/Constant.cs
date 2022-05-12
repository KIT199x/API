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
        public const string DataSuccess = "Lấy dữ liệu thành công";
        public const string DataError = "Lấy dữ liệu thất bại";


        #region status
        public const int ErrorCode = 201;
        public const int SuccessCode = 201;
        #endregion
    }
}
