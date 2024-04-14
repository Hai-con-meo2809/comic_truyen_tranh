using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web_BanSach.Models;

namespace Web_BanSach.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
             public virtual DbSet<Account> Accounts { get; set; }

        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Cart> Carts { get; set; }

        public virtual DbSet<Genre> Genres { get; set; }

        public virtual DbSet<OrderInfo> OrderInfos { get; set; }

        public virtual DbSet<Review> Reviews { get; set; }

        public virtual DbSet<User> Nguoidung { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }

    
}
}