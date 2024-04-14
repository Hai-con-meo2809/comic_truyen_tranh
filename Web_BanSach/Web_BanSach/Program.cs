using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Web_BanSach.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));



builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => { options.SignIn.RequireConfirmedAccount = true;
    options.SignIn.RequireConfirmedEmail = true; // Yêu cầu xác nhận tài khoản
    options.Password.RequiredLength = 1; // Độ dài tối thiểu của mật khẩu
    options.Password.RequireDigit = false; // Yêu cầu ít nhất một chữ số
    options.Password.RequireLowercase = false; // Yêu cầu ít nhất một chữ thường
    options.Password.RequireUppercase = false; // Yêu cầu ít nhất một chữ hoa
    options.Password.RequireNonAlphanumeric = false; // Yêu cầu ít nhất một ký tự đặc biệt
}
)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();


builder.Services.AddLogging();
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();



app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Home}/{id?}"
	);

	endpoints.MapControllerRoute(
		name: "ProductDetails",
		pattern: "Customer/Shop/Details/{id}", // Định nghĩa một tuyến đường cho trang chi tiết sản phẩm
		defaults: new { controller = "Shop", action = "Details" }
	);


});

app.MapRazorPages();

app.Run();
