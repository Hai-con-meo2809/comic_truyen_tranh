using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_BanSach.Models;

public class Account
{
	[Key]
	public string Taikhoan { get; set; }

	public string Matkhau { get; set; }

	public string MaKh { get; set; }
}

