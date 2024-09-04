using Microsoft.EntityFrameworkCore;
using WILTestDesignSpace;
using WILTestDesignSpace.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//added in - used for session strings 
builder.Services.AddMvc();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();

string connectionString = Environment.GetEnvironmentVariable("bumblebeeconnstring");


builder.Services.AddDbContext<BumbleBeesContext>(options =>
    options.UseSqlServer(connectionString));
var app = builder.Build();

app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=About}/{id?}");

app.Run();
