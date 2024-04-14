using Web_BanSach.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Web_BanSach.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int Masach { get; set; }

    public int MaKh { get; set; }

    public double? Rating { get; set; }

    public string? Nhanxet { get; set; }

    // Không cần khởi tạo ICollection mới ở đây
    [ForeignKey("MaKh")]
    [ValidateNever]
    public virtual User Nguoidung { get; set; }
    [ForeignKey("Masach")]
    [ValidateNever]
    public virtual Book Book { get; set; }
}

