using Microsoft.EntityFrameworkCore;
using MinecraftStore.Data;
using MinecraftStore.Data.Service;
using MinecraftStore.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("AppIdentityDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AppIdentityDbContextConnection' not found.");

// Add services to the container.

//Database data
builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(builder.Configuration["Data:Connection"]));

builder.Services.AddScoped<IProductService<Product>, ProductService>();


//Database identity
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppIdentityDbContext>(options =>
    options.UseSqlServer(
    builder.Configuration["Data:AppIdentity:ConnectionString"]));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddMemoryCache();
builder.Services.AddSession();


var app = builder.Build();

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
app.UseAuthentication();;

app.UseAuthorization();


app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthentication();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

IdentitySeedData.EnsurePopulated(app);

app.Run();
