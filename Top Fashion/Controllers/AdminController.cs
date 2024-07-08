using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Top_Fashion.TopFashion.Domain.Dtos;
using Top_Fashion.TopFashion.Domain.Entities;
using Top_Fashion.TopFashion.Domain.Services;
using Top_Fashion.TopFashion.Main.Errors;

namespace Top_Fashion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenServices _tokenServices;
        private readonly IMapper _mapper;
        public AdminController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenServices tokenServices, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenServices = tokenServices;
            _mapper = mapper;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            if ((dto.Email) == "admin@gmail.com")
            {
                var user = await _userManager.FindByEmailAsync(dto.Email);
                if (user is null) return Unauthorized(new BaseCommonResponse(401));

                // var result = await _userManager.CheckPasswordAsync(user, dto.Password);
                var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
                if (result is null || result.Succeeded == false) return Unauthorized(new BaseCommonResponse(401));

                return Ok(new UserDto
                {
                    DisplayName = user.DisplayName,
                    Email = user.Email,
                    Token = _tokenServices.CreateTokenadmin(user)
                });
            }
            else return Unauthorized(new BaseCommonResponse(401));

        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if ((dto.Email) == "admin@gmail.com")
            {

                var user = new AppUser
                {
                    DisplayName = dto.DisplayName,
                    UserName = dto.Email,
                    Email = dto.Email,
                    PhoneNumber = dto.PhoneNumber
                };
                var result = await _userManager.CreateAsync(user, dto.Password);
                if (result.Succeeded == false) return BadRequest(new BaseCommonResponse(400));
                return Ok(new UserDto
                {
                    DisplayName = dto.DisplayName,
                    Email = dto.Email,
                    Token = _tokenServices.CreateTokenadmin(user)
                });
            }
            else return Unauthorized(new BaseCommonResponse(401));
        }





        /* [HttpPost]
         [Route("auth")]
         public ActionResult<string> authuser(string username, string password)
         {
             if (username == "anaakl" && password == "01276120322")
             {
                 var tokenHandler = new JwtSecurityTokenHandler();
                 var tokendescriptor = new SecurityTokenDescriptor
                 {
                     Issuer = "Top Fashion",

                     new(ClaimTypes.Role, "Admin")
                 };
                 var securitytoken = tokenHandler.CreateToken(tokendescriptor);
                 var accesstoken = tokenHandler.WriteToken(securitytoken);
                 return Ok(accesstoken);
             }
         }*/
    }
}
