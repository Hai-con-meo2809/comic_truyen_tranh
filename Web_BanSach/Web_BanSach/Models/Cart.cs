using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_BanSach.Models;

public class Cart
{
	[Key]
	public int CartId { get; set; }

	public int MaKh { get; set; }

	public int Masach { get; set; }

	public int Soluong { get; set; }

	public int Giatien { get; set; }

	public int Tongtien { get; set; }
    public string IDUsers { get; set; }
    [ForeignKey("AppUserId")]
    [ValidateNever]
    public ApplicationUser applications { get; set; }

    [ForeignKey("MaKh")]
    [ValidateNever]
    public virtual User User { get; set; }
    [ForeignKey("Masach")]
    [ValidateNever]
    public virtual Book Book { get; set; }
    [ValidateNever]
    public virtual ICollection<OrderInfo> OrderInfos { get; set; }

}
