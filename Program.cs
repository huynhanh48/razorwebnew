using Microsoft.EntityFrameworkCore;
using MigrationsExample.Models;
using Microsoft.AspNetCore.Identity; 

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
string connections = builder.Configuration.GetConnectionString("MyBlogContext");
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<MyBlogContext>(
    option => option.UseSqlServer(connections)
);
services.AddDefaultIdentity<AppUser>()
        .AddEntityFrameworkStores<MyBlogContext>()
        .AddDefaultTokenProviders();

// services.AddIdentity<AppUser, IdentityRole>()
//         .AddEntityFrameworkStores<MyBlogContext>()
//         .AddDefaultTokenProviders();
        services.Configure<IdentityOptions> (options => {
    // Thiết lập về Password
    options.Password.RequireDigit = false; // Không bắt phải có số
    options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
    options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
    options.Password.RequireUppercase = false; // Không bắt buộc chữ in
    options.Password.RequiredLength = 3; // Số ký tự tối thiểu của password
    options.Password.RequiredUniqueChars = 1; // Số ký tự riêng biệt

    // Cấu hình Lockout - khóa user
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes (5); // Khóa 5 phút
    options.Lockout.MaxFailedAccessAttempts = 5; // Thất bại 5 lầ thì khóa
    options.Lockout.AllowedForNewUsers = true;

    // Cấu hình về User.
    options.User.AllowedUserNameCharacters = // các ký tự đặt tên user
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;  // Email là duy nhất

    // Cấu hình đăng nhập.
    options.SignIn.RequireConfirmedEmail = true;            // Cấu hình xác thực địa chỉ email (email phải tồn tại)
    options.SignIn.RequireConfirmedPhoneNumber = false;     // Xác thực số điện thoại

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();



  /*  private const string connectionString = @"
                Data Source=localhost,1433;
                Initial Catalog=HuynhANh;
                User ID=SA;Password=482004;Integrated Security=True;
                TrustServerCertificate=True;Encrypt=True"
                ; */
// create , read ,update,deleta
// dotnet aspnetgenerator razorpage -m MigrationsExample.Models.Articel -dc MigrationsExample.Models.MyBlogContext -outDir Pages/Blog --referenceScriptLibraries
// Identity/Account/Login