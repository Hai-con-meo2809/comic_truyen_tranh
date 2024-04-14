using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using Web_BanSach.Data;
using Web_BanSach.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace Web_BanSach.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _db;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var book = _db.Books.ToList();

            var tolist = _db.Carts.Include("Book").ToList();

            var viewModel = new BookCartViewModel
            {
                Books = book,
                Carts = tolist,
            };
            return View(book);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        ///////////////////////////////////////////////////////////////////////////////
        public IActionResult Home()
        {

            var book = _db.Books.ToList();
            //var identity = (ClaimsIdentity)User.Identity;
            //var claim = identity.FindFirst(ClaimTypes.NameIdentifier);
            //var tolist = _db.Carts.Include("Book").Where(x => x.IDUsers == claim.Value).ToList();

            //var viewModel = new BookCartViewModel
            //{
            //    Books = book,
            //    Carts = tolist,
            //};
            return View(book);
        }

        public IActionResult Details(int id)
        {
            var ids = _db.Books.FirstOrDefault(x => x.Masach == id);
            return View(ids);
        }
        [HttpGet]
        public IActionResult Cart()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var claim = identity.FindFirst(ClaimTypes.NameIdentifier);
            var tolist = _db.Carts.Include("Book").Where(x => x.IDUsers == claim.Value).ToList();

            var viewModel = new BookCartViewModel
            {

                Carts = tolist,
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cart(int masach, int quantity)
        {
            var check = _db.Books.FirstOrDefault(x => x.Masach == masach);
            var identity = (ClaimsIdentity)User.Identity;
            var claim = identity.FindFirst(ClaimTypes.NameIdentifier);
            var tolist = _db.Carts.Include("Book").Where(x => x.IDUsers == claim.Value).ToList();
           var info = _db.Carts.OrderBy(x => x.Tongtien).Where(x => x.IDUsers == claim.Value);
            ViewBag.tongtien = 0;
            var idUser = _db.Carts.FirstOrDefault(x => x.IDUsers == claim.Value && x.Masach == masach);
            if (idUser == null)
            {
               

                var giohang = new Cart
                {
                    Masach = check.Masach,
                    Giatien = check.Giatien,
                    Soluong = quantity,
                    IDUsers = claim.Value,
                    Tongtien = check.Giatien * quantity,
                    MaKh = 1,
                };
                var viewModel = new BookCartViewModel
                {
                   
                    Carts = tolist,
                };
             

                _db.Carts.Add(giohang);
              
                _db.SaveChanges();
                foreach (var id in tolist)
                {
                    ViewBag.tongtien += id.Tongtien;
                }
                return View(viewModel);
            }

            else
            {
                idUser.Soluong += quantity;
                idUser.Tongtien = idUser.Soluong * idUser.Giatien;
              
                _db.SaveChanges();
                foreach (var id in tolist)
                {
                    ViewBag.tongtien += id.Tongtien;
                }
                var viewModel = new BookCartViewModel
                {

                    Carts = tolist,
                };

                return View(viewModel);
            }


        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {

            // Kiểm tra thông tin đăng nhập ở đây
            if (IsValidLogin(username, password))
            {
                // Đăng nhập thành công, lưu trạng thái đăng nhập vào session
                HttpContext.Session.SetString("IsAuthenticated", "true");
                HttpContext.Session.SetString("Username", username);

                // Chuyển hướng đến trang mong muốn
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Đăng nhập không thành công, hiển thị thông báo lỗi hoặc chuyển hướng trở lại trang đăng nhập
                return View();
            }
        }
        private bool IsValidLogin(string username, string password)
        {
            // Trong ví dụ này, tạm thời sẽ trả về true mà không xác thực thực sự
            return true;
        }
    }





    
    
}