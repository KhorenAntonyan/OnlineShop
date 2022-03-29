using Microsoft.EntityFrameworkCore;
//using OnlineShop.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

//string connection = builder.Configuration.GetConnectionString("DefaultConnection");

//builder.Services.AddDbContext<OnlineShopDbContext>(options => options.UseSqlServer(connection));

var app = builder.Build();

//app.MapGet("/", (OnlineShopDbContext db) => db.Products.ToList());

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.MapGet("/", () => "Hello World!");

app.Run();
