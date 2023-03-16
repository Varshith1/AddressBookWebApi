using AddressBook.Models.Models;
using AddressBookWebAPI.Repository.Dapper;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using Dapper.Contrib.Extensions;
using AddressBookServices.Interfaces;

namespace AddressBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public IAuthentificatinServices services { get; set; }

        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public AuthenticationController(IConfiguration config, IAuthentificatinServices _services , IMapper mapper)
        {
            services = _services;
            _mapper = mapper;
            _configuration = config;
        }

        [HttpPost("Register")]
        public  void Register(UserRegister register)
        {
            var loginDetails = _mapper.Map<LoginDetails>(register);
            services.AddUser(loginDetails);
        }
        [HttpPost("Login")]
        public async Task<string> Login(Login request)
        {
       
            var user = services.GetUserLoginDetails(request);
            if (user == null)
            {
                return "User Did not exist";
            }
            return CreateToken(user);
        }


        private string CreateToken(LoginDetails user)
        {
            List<Claim> claims = new List<Claim>
            {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, user.Role)
            }; 
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
            _configuration.GetSection("AppSettings:Token").Value)); 
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature); 
            var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
