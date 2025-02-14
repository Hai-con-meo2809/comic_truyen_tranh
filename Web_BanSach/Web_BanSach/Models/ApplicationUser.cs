﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Web_BanSach.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Names { get; set; }
        public string? Address { get; set; }
        public int PhoneNumbers { get; set; }
        public ICollection<Cart> Carts { get; set; }
    }
}
