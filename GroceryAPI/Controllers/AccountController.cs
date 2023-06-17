using GroceryAPI.Data;
using GroceryAPI.Models;
using GroceryAPI.Models.Dto;
using GroceryAPI.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Unicode;

namespace GroceryAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDBContext _db;
        private readonly ApiResponse response;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private string secret;
        public AccountController(ApplicationDBContext db,
            IConfiguration configuration,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            response = new ApiResponse
            {
                Message = new List<string>()
            };
            _userManager = userManager;
            _roleManager = roleManager;
            secret = configuration.GetValue<string>("AppSettings:Secret");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDto registerRequestDto)
        {
            try
            {
                var user = _db.ApplicationUsers
                .FirstOrDefault(x => x.UserName.ToLower() == registerRequestDto.UserName.ToLower());
                if (user != null)
                {
                    response.IsSuccess = false;
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    return BadRequest(response);
                }

                var newUser = new ApplicationUser
                {
                    UserName = registerRequestDto.UserName,
                    FullName = registerRequestDto.Name,
                    Email = registerRequestDto.UserName,
                    NormalizedEmail = registerRequestDto.UserName.ToUpper(),
                };

                var result = await _userManager.CreateAsync(newUser, registerRequestDto.Password);

                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
                    {
                        //Create Role In DB If Not Exist
                        await _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin));
                        await _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer));
                    }

                    if (registerRequestDto.Role.ToLower() == SD.Role_Admin)
                    {
                        await _userManager.AddToRoleAsync(newUser, SD.Role_Admin);
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(newUser, SD.Role_Customer);
                    }

                    response.IsSuccess = true;
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Message = new List<string> { ex.Message };
                return BadRequest(response);
            }

            response.IsSuccess = false;
            response.StatusCode = System.Net.HttpStatusCode.BadRequest;
            return BadRequest(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
            try
            {
                var userFromDb = _db.ApplicationUsers
                .FirstOrDefault(x => x.UserName.ToLower() == loginRequestDto.UserName.ToLower());

                var isValid = await _userManager.CheckPasswordAsync(userFromDb, loginRequestDto.Password);

                if (!isValid)
                {
                    response.IsSuccess = false;
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    response.Message.Add("UserName or Password is incorrect");
                    return BadRequest(response);
                }

                //Generate JWT Token
                var roles = await _userManager.GetRolesAsync(userFromDb);
                JwtSecurityTokenHandler tokenHandler = new();
                byte[] key = Encoding.ASCII.GetBytes(secret);

                SecurityTokenDescriptor tokenDescriptor = new()
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("fullname", userFromDb.FullName),
                        new Claim("id", userFromDb.Id),
                        new Claim(ClaimTypes.Email, userFromDb.Email),
                        new Claim(ClaimTypes.Role, roles.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials =new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

                var loginResponse = new LoginResponseDto
                {
                    Email = loginRequestDto.UserName,
                    Token = tokenHandler.WriteToken(token),
                };

                if (loginResponse.Email == null || string.IsNullOrEmpty(loginResponse.Token))
                {
                    response.IsSuccess = false;
                    response.StatusCode= System.Net.HttpStatusCode.BadRequest;
                    return BadRequest(response);
                }

                response.IsSuccess = true;
                response.Result = loginResponse;
                response.StatusCode=System.Net.HttpStatusCode.OK;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Message = new List<string> { ex.Message };
                return BadRequest(response);
            }
        }
    }
}

