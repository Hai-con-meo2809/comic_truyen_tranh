using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace	Web_BanSach.Models;

public class OrderInfo
{
	[Key]
	public int MaDh { get; set; }

	public int CartId { get; set; }

	public int MaKh { get; set; }

	public string HọTên { get; set; }

	public string Email { get; set; }

	public int Sdt { get; set; }

	public string Diachi { get; set; }

	public string? Ghichu { get; set; }
    
    [ForeignKey("CartId")]
    [ValidateNever]
    public virtual Cart Cart { get; set; }

    [ForeignKey("MaKh")]
    [ValidateNever]
    public virtual User Nguoidung { get; set; }
}
