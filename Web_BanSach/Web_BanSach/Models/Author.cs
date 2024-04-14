using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_BanSach.Models;

public class Author
{
	[Key]
	public int Matacgia { get; set; }

	public string Tentacgia { get; set; }

	public string TieusuTg { get; set; }
    [ValidateNever]

    public virtual ICollection<Book> Books { get; set; }
}


