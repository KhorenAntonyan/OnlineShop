﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.BLL.Mapping;
using OnlineShop.BLL.Services.Abstractions;
using OnlineShop.BLL.Services.Implementations;
using OnlineShop.DAL.Contexts;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.Repositories.Abstractions;
using OnlineShop.DAL.Repositories.Implementations;
using OnlineShop.Web.Admin.Mapping;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContext<OnlineShopDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<OnlineShopDbContext>();

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<WebMappingProfile>();
    config.AddProfile<BLLMappingProfile>();
});

builder.Services.AddControllersWithViews();
builder.Services.AddMvcCore();
builder.Services.AddHttpContextAccessor();


builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IPhotoService, PhotoService>();
builder.Services.AddSingleton<IFilterService, FilterService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddMvc().AddRazorPagesOptions(options => {
    options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "");
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages().RequireAuthorization();
});

app.Run();
