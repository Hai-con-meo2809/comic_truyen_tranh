using Microsoft.AspNetCore.Mvc;
using Web_BanSach.Models;

namespace Web_BanSach.Controllers
{
	public class VnpayPayController : Controller
	{
		public IActionResult Index()
		{
			return View(new vnpay_return());
		}
		[HttpPost]
		public IActionResult Pay(vnpay_return model)
		{
			// Xử lý logic thanh toán ở đây

			return RedirectToAction("Index");
		}
	}
}
