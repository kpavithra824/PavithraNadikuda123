using AdminMicroServices.Models;
using AdminMicroServices.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AdminMicroServices.Services
{
    public class JwtManagerRepository : IJwtManagerRepository
    {
        Dictionary<string, string> adminRecords;

        private readonly FightAirlineDBContext admindb;
        private readonly IConfiguration configuration;
        public JwtManagerRepository(IConfiguration _configuration, FightAirlineDBContext _admindb)
        {
            configuration = _configuration;
            admindb = _admindb;
        }

        public Tokens Anthenticate(AdminLoginViewModel users, bool IsRegister)
        {
            if (IsRegister)
            {
                if (admindb.TblAdminLogins.Any(x => x.UserName == users.UserName))
                {
                    return null;
                }

                TblAdminLogin tbladminlogin = new TblAdminLogin();
                tbladminlogin.UserName = users.UserName;
                tbladminlogin.Password = users.Password;
                admindb.TblAdminLogins.Add(tbladminlogin);
                admindb.SaveChanges();
            }
            adminRecords = admindb.TblAdminLogins.ToList().ToDictionary(x => x.UserName, x => x.Password);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = System.Text.Encoding.UTF8.GetBytes(configuration["JWT:KEY"]);
            if (!adminRecords.Any(x => x.Key == users.UserName && x.Value == users.Password))
            {
                return null;
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.Name,users.UserName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };
        }

        public List<TblAdminLogin> FindAll()
        {
            return admindb.TblAdminLogins.ToList();
        }
    }
}
