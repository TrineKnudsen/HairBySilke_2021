using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using HBS.HairBySilke_2021.Security.IServices;
using HBS.HairBySilke_2021.Security.models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HBS.HairBySilke_2021.Security.Services
{
    public class SecurityService: ISecurityService
    {
        private readonly IAuthUserService _authUserService;

        public SecurityService(IConfiguration configuration,
                                IAuthUserService authUserService)
        {
            _authUserService = authUserService;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public JwtToken GenerateJwtToken(string username, string password)
        {
            var user = _authUserService.Login(username, password);
            
            //validate user - generate
            if (user != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Secret"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(Configuration["Jwt:Issuer"],
                    Configuration["Jwt:Audience"],
                    null,
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: credentials);
                return new JwtToken
                {
                    Jwt = new JwtSecurityTokenHandler().WriteToken(token),
                    Message = "Ok"
                };
            }

            return new JwtToken
            {
                Message = "User or password not correct"
            };
        }
    }
}