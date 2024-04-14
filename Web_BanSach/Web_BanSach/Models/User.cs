using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Web_BanSach.Models;

namespace Web_BanSach.Models;

public partial class User
{
	[Key]
    [Required]
	public int MaKh { get; set; }

    public string Taikhoan { get; set; } = null!;

    public string Matkhau { get; set; } = null!;

    public string TenKh { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Diachi { get; set; } = null!;

    public string IDUsers { get; set; } 
    public int Sdt { get; set; }
    [ValidateNever]
    public virtual ICollection<Cart> Carts { get; set; }
    [ValidateNever]
    public virtual ICollection<OrderInfo> OrderInfos { get; set; }
    [ValidateNever]
    public virtual ICollection<Review> Reviews { get; set; } 
}
