using Microsoft.AspNetCore.Mvc;
using Common;

namespace API.Controllers
{
    [ApiController]
    [Route("api/QRCode")]
    public class QRCodeController : Controller
    {
        [HttpGet]
        [Route("GenerateQRCode")]
        public string GenerateQRCode(string QRCodeText)
        {
            return QR.CreateQRCode(QRCodeText);
        }
    }
}
