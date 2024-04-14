using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_BanSach.Models;

public class Genre
{
	[Key]
	public int TheloaiId { get; set; }

	public string TenTl { get; set; }
    [ValidateNever]

    public virtual ICollection<Book> Books { get; set; }
}

