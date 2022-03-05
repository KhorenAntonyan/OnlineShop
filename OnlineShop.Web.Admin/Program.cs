using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Infrastructure.Data;
using OnlineShop.Web.Admin.Services;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "localhost",
            ValidateAudience = true,
            ValidAudience = "localhost",
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysupersecret_secretkey!123")),
            ValidateIssuerSigningKey = true,
        };
    });

//builder.Services.AddAuthorization(opts => {

//    //opts.AddPolicy("OnlyForMicrosoft", policy => {
//    //    policy.RequireClaim("company", "Microsoft");
//    //});
//});

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IUserService, UserService>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapGet("Auth/Login", async (HttpContext context) =>
//{

//    var claimsIdentity = new ClaimsIdentity("Bearer");
//    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
//    await context.SignInAsync(claimsPrincipal);
//    //return Results.Redirect("Auth/Login");
//});

//app.MapGet("Auth/Login", async (HttpContext context) =>
//{
//    var username = "User";

//    var claims = new List<Claim>
//    {
//        new Claim (ClaimTypes.Name, username),
//    };
//    var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
//    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
//    await context.SignInAsync(claimsPrincipal);
//    return Results.Redirect("/");
//});

//app.Map("Auth/Login", async (HttpContext context) =>
//{
//    // получаем из формы email и пароль
//    var form = context.Request.Form;
//    // если email и/или пароль не установлены, посылаем статусный код ошибки 400
//    if (!form.ContainsKey("email") || !form.ContainsKey("password"))
//        return Results.BadRequest("Email и/или пароль не установлены");
//    string email = form["email"];
//    string password = form["password"];

//    // находим пользователя 
//    //Person? person = people.FirstOrDefault(p => p.Email == email && p.Password == password);
//    // если пользователь не найден, отправляем статусный код 401
//    //if (person is null) return Results.Unauthorized();
//    var claims = new List<Claim>
//    {
//        new Claim(ClaimTypes.Name, email),
//        //new Claim(ClaimTypes.Locality, password),
//        //new Claim("company", person.Company)
//    };
//    var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
//    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
//    await context.SignInAsync(claimsPrincipal);
//    return Results.Redirect("/");
//});

//app.Map("/", (HttpContext context) =>
//{
//    var user = context.User.Identity;
//    if (user is not null && user.IsAuthenticated)
//        return Results.Redirect("Home/Index");
//    else
//        return Results.Redirect("Auth/Login");
//});

app.Run();
