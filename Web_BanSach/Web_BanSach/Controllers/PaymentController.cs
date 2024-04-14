using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Policy;
using Web_BanSach.Data;
using Web_BanSach.Models;

namespace Web_BanSach.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ILogger<PaymentController> _logger;
        private readonly ApplicationDbContext _db;
        public PaymentController(IConfiguration config, ILogger<PaymentController> logger, ApplicationDbContext db)
        {
            _config = config;
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            
            var identity = (ClaimsIdentity)User.Identity;
            var claim = identity.FindFirst(ClaimTypes.NameIdentifier);
            var claims = identity.FindFirst(ClaimTypes.Name);
            var tolist = _db.Carts.FirstOrDefault(x => x.IDUsers == claim.Value);
            var tolists = _db.Carts.Include("Book").Where(x => x.IDUsers == claim.Value).ToList();
            ViewBag.tongtien = 0;
            ViewBag.taikhoan = claims.Value;
            foreach (var id in tolists)
            {
                ViewBag.tongtien += id.Tongtien;
            }
            return View(tolist);
        }

        [HttpPost]
        public IActionResult ProcessPayment(OrderInfos order)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var claim = identity.FindFirst(ClaimTypes.NameIdentifier);
            var tolists = _db.Carts.Include("Book").Where(x => x.IDUsers == claim.Value).ToList();
            ViewBag.tongtien = 0;
            foreach (var id in tolists)
            {
                ViewBag.tongtien += id.Tongtien;
            }
            var total = ViewBag.tongtien;
            // Lấy thông tin cấu hình từ appsettings.json
            var vnp_Url = _config["VNPAY:Url"];
            var vnp_TmnCode = _config["VNPAY:TmnCode"];
            var vnp_HashSecret = _config["VNPAY:HashSecret"];
            var vnp_Returnurl = _config["VNPAY:ReturnUrl"];

            var pay = new VnPayLibrary();

            // Thêm các thông tin cần thiết vào request
            pay.AddRequestData("vnp_Version", "2.1.0");
            //Mã API sử dụng, mặc định là 'pay'
            pay.AddRequestData("vnp_Command", "pay");
            //Mã website của merchant (không bắt buộc)
            pay.AddRequestData("vnp_TmnCode", vnp_TmnCode);
            //Số tiền (thanh toán) cần chuyển, số cố định 100 * 100 - vì dụ 10.000 (mười nghìn đồng) --> 100 * 100 = 1000000
            pay.AddRequestData("vnp_Amount", (total * 100).ToString());
            //Ngân hàng thanh toán (tham khảo: https://sandbox.vnpayment.vn/apis/danh-sach-ngan-hang/)
            pay.AddRequestData("vnp_BankCode", "VNBANK");
            //Ngày thanh toán (theo định dạng yyyyMMddHHmmss)
            pay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
            //Loại tiền tệ (mặc định: 'VND')
            pay.AddRequestData("vnp_CurrCode", "VND");
            //Địa chỉ IP của khách hàng thực hiện giao dịch
            pay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress(HttpContext));
            //Ngôn ngữ của người thực hiện tiếng Việt (vn), Tiếng Anh (en)
            pay.AddRequestData("vnp_Locale", "vn");
            //Thời gian thực hiện giao dịch (theo định dạng yyyyMMddHHmmss)
            pay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang");
            //Thông tin mô tả giao dịch
            pay.AddRequestData("vnp_OrderType", "billpayment: Thanh toan hoa don - fashion: Thoi trang - other: Thanh toan truc tuyen khac");
            //Đường dẫn trả kết quả cho website
            pay.AddRequestData("vnp_ReturnUrl", vnp_Returnurl);
            //Mã hóa đơn
            pay.AddRequestData("vnp_TxnRef", DateTime.Now.Ticks.ToString());






            string paymentUrl = pay.CreateRequestUrl(vnp_Url, vnp_HashSecret);

        
            return Redirect(paymentUrl);
      
        }

        // Endpoint để nhận phản hồi từ VNPAY
        public  IActionResult VnPayReturn()
        {
            // Xử lý phản hồi từ VNPAY, ví dụ: cập nhật trạng thái đơn hàng
            _logger.LogInformation("Begin VNPAY Return, URL={0}", HttpContext.Request.Path);
            if (Request.Query.Count > 0)
            {
                string vnp_HashSecret = _config["VNPAY:HashSecret"]; // Chuỗi bí mật
                var vnpayData = Request.Query;
                VnPayLibrary vnpay = new VnPayLibrary();

                foreach (var key in vnpayData.Keys)
                {
                    // Lấy tất cả dữ liệu từ query string
                    if (key.StartsWith("vnp_"))
                    {
                        vnpay.AddResponseData(key, vnpayData[key]);
                    }
                }
                //vnp_TxnRef: Mã đơn hàng merchant gửi VNPAY khi command=pay    
                //vnp_TransactionNo: Mã giao dịch trên hệ thống VNPAY
                //vnp_ResponseCode: Mã phản hồi từ VNPAY: 00: Thành công, Khác 00: Xem tài liệu
                //vnp_SecureHash: HmacSHA512 của dữ liệu trả về

                long orderId = Convert.ToInt64(vnpay.GetResponseData("vnp_TxnRef"));
                long vnpayTranId = Convert.ToInt64(vnpay.GetResponseData("vnp_TransactionNo"));
                string vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
                string vnp_TransactionStatus = vnpay.GetResponseData("vnp_TransactionStatus");
                string vnp_SecureHash = Request.Query["vnp_SecureHash"];
                string terminalId = Request.Query["vnp_TmnCode"];
                long vnp_Amount = Convert.ToInt64(vnpay.GetResponseData("vnp_Amount")) / 100;
                string bankCode = Request.Query["vnp_BankCode"];

                bool checkSignature = vnpay.ValidateSignature(vnp_SecureHash, vnp_HashSecret);
                if (checkSignature)
                {
                    if (vnp_ResponseCode == "00" && vnp_TransactionStatus == "00")
                    {
                        // Thanh toán thành công
                        ViewBag.Message = "Giao dịch được thực hiện thành công. Cảm ơn quý khách đã sử dụng dịch vụ";
                        _logger.LogInformation("Thanh toan thanh cong, OrderId={0}, VNPAY TranId={1}", orderId, vnpayTranId);
                    }
                    else
                    {
                        // Thanh toán không thành công. Mã lỗi: vnp_ResponseCode
                        ViewBag.Message = "Có lỗi xảy ra trong quá trình xử lý. Mã lỗi: " + vnp_ResponseCode;
                        _logger.LogInformation("Thanh toan loi, OrderId={0}, VNPAY TranId={1}, ResponseCode={2}", orderId, vnpayTranId, vnp_ResponseCode);
                    }
                    ViewBag.TerminalId = "Mã Website (Terminal ID):" + terminalId;
                    ViewBag.OrderId = "Mã giao dịch thanh toán:" + orderId.ToString();
                    ViewBag.VnPayTranId = "Mã giao dịch tại VNPAY:" + vnpayTranId.ToString();
                    ViewBag.Amount = "Số tiền thanh toán (VND):" + vnp_Amount.ToString();
                    ViewBag.BankCode = "Ngân hàng thanh toán:" + bankCode;
                }
                else
                {
                    _logger.LogInformation("Invalid signature, InputData={0}", Request.QueryString);
                    ViewBag.Message = "Có lỗi xảy ra trong quá trình xử lý";
                }
            }

            return View();
        }
    }

}
