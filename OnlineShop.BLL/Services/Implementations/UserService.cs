

namespace OnlineShop.BLL.Services.Implementations
{
    public class UserService //: IUserService
    {
        //private readonly UserManager<IdentityUser> _userManager;
        //private readonly RoleManager<IdentityRole> _roleManager;
        //private readonly IConfiguration _configuration;

        //public UserService(
        //    UserManager<IdentityUser> userManager,
        //    RoleManager<IdentityRole> roleManager,
        //    IConfiguration configuration)
        //{
        //    _userManager = userManager;
        //    _roleManager = roleManager;
        //    _configuration = configuration;
        //}

        //public async Task<UserManagerResponse> Login(LoginViewModel model)
        //{
        //    var user = await _userManager.FindByNameAsync(model.Email);

        //    if (user == null)
        //    {
        //        return new UserManagerResponse
        //        {
        //            Message = "There is no with that Email address",
        //            IsSuccess = false,
        //        };
        //    }

        //    var result = await _userManager.CheckPasswordAsync(user, model.Password);

        //    if (!result)
        //    {
        //        return new UserManagerResponse
        //        {
        //            Message = "Invalid password",
        //            IsSuccess = false,
        //        };
        //    }

        //    var userRoles = await _userManager.GetRolesAsync(user);

        //    var authClaims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, user.UserName),
        //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //        };

        //    foreach (var userRole in userRoles)
        //    {
        //        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        //    }

        //    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        //    var token = new JwtSecurityToken(
        //        issuer: _configuration["JWT:ValidIssuer"],
        //        audience: _configuration["JWT:ValidAudience"],
        //        expires: DateTime.Now.AddHours(3),
        //        claims: authClaims,
        //        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        //        );

        //    //var token = GetToken(authClaims);
        //    var tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

        //    return new UserManagerResponse
        //    {
        //        Message = tokenAsString,
        //        IsSuccess = true,
        //        ExpireDate = token.ValidTo,
        //    };
        //}


        //public async Task<UserManagerResponse> Register(RegisterViewModel model)
        //{
        //    if (model == null)
        //        throw new NullReferenceException("Register Model is null");

        //    if (model.Password != model.ConfirmPassword)
        //        return new UserManagerResponse
        //        {
        //            Message = "Confirm password does not match the pssword"
        //        };

        //    var userExists = await _userManager.FindByNameAsync(model.Email);

        //    if (userExists != null)
        //        return new UserManagerResponse
        //        {
        //            Message = "Not found Email"
        //        };

        //    IdentityUser user = new()
        //    {
        //        Email = model.Email,
        //        SecurityStamp = Guid.NewGuid().ToString(),
        //        UserName = model.Email
        //    };

        //    var result = await _userManager.CreateAsync(user, model.Password);

        //    if (result.Succeeded)
        //    {
        //        return new UserManagerResponse
        //        {
        //            Message = "User created successfully!",
        //            IsSuccess = true,
        //        };
        //    }

        //    return new UserManagerResponse
        //    {
        //        Message = "User did not create",
        //        IsSuccess = false,
        //        Errors = result.Errors.Select(e => e.Description)
        //    };
        //}

        //[HttpPost]
        //[Route("register-admin")]
        //public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        //{
        //    var userExists = await _userManager.FindByNameAsync(model.Username);
        //    if (userExists != null)
        //        return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

        //    IdentityUser user = new()
        //    {
        //        Email = model.Email,
        //        SecurityStamp = Guid.NewGuid().ToString(),
        //        UserName = model.Username
        //    };
        //    var result = await _userManager.CreateAsync(user, model.Password);
        //    if (!result.Succeeded)
        //        return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

        //    if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
        //        await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        //    if (!await _roleManager.RoleExistsAsync(UserRoles.User))
        //        await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        //    if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
        //    {
        //        await _userManager.AddToRoleAsync(user, UserRoles.Admin);
        //    }
        //    if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
        //    {
        //        await _userManager.AddToRoleAsync(user, UserRoles.User);
        //    }
        //    return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        //}

        //private JwtSecurityToken GetToken(List<Claim> authClaims)
        //{
        //    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        //    var token = new JwtSecurityToken(
        //        issuer: _configuration["JWT:ValidIssuer"],
        //        audience: _configuration["JWT:ValidAudience"],
        //        expires: DateTime.Now.AddHours(3),
        //        claims: authClaims,
        //        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        //        );

        //    return token;
        //}
    }
}
