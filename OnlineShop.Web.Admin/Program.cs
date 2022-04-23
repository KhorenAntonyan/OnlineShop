using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.BLL.Mapping;
using OnlineShop.BLL.Services.Abstractions;
using OnlineShop.BLL.Services.Implementations;
using OnlineShop.DAL.Contexts;
using OnlineShop.DAL.Repositories.Abstractions;
using OnlineShop.DAL.Repositories.Implementations;
using OnlineShop.Web.Admin.Mapping;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContext<OnlineShopDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<OnlineShopDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = configuration["JWT:ValidAudience"],
            ValidIssuer = configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
        };
    });

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidIssuer = "localhost",
//            ValidateAudience = true,
//            ValidAudience = "localhost",
//            ValidateLifetime = true,
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysupersecret_secretkey!123")),
//            ValidateIssuerSigningKey = true,
//        };
//    });

//builder.Services.AddAuthorization(opts => {

//    //opts.AddPolicy("OnlyForMicrosoft", policy => {
//    //    policy.RequireClaim("company", "Microsoft");
//    //});
//});

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
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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

//app.MapControllers();

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

app.Run();
