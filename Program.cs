using Microsoft.EntityFrameworkCore;
using MigrationsExample.Models;

var builder = WebApplication.CreateBuilder(args);
string connections = builder.Configuration.GetConnectionString("MyBlogContext");
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<MyBlogContext>(
    option => option.UseSqlServer(connections)
);

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