using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_BanSach.Models;

public class Book
{
	[Key]
	public int Masach { get; set; }

	public string Tensach { get; set; }

	public int TheloaiId { get; set; }

	public int TacgiaId { get; set; }

	public int? Soluong { get; set; }

	public int Giatien { get; set; }

	public DateTime Ngayxuatban { get; set; }

	public string ImageUrl { get; set; }

	public string MotaVesach { get; set; }
    [ValidateNever]

    public virtual ICollection<Cart> Carts { get; set; }
    [ValidateNever]

    public virtual ICollection<Review> Reviews { get; set; }
    [ValidateNever]

    [ForeignKey("TheloaiId")]
    public virtual Genre Genre { get; set; }

    [ValidateNever]
    [ForeignKey("TacgiaId")]
    public virtual Author Author { get; set; }
}

