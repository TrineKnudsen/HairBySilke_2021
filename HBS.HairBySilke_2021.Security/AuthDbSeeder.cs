using System.Text;
using HBS.HairBySilke_2021.Security.Entities;
using HBS.HairBySilke_2021.Security.IServices;

namespace HBS.HairBySilke_2021.Security
{
    public class AuthDbSeeder: IAuthDbSeeder
    {
        private readonly AuthDbContext _ctx;
        private readonly ISecurityService _securityService;

        public AuthDbSeeder(AuthDbContext ctx,
                            ISecurityService securityService)
        {
            _ctx = ctx;
            _securityService = securityService;
        }
        
        public void SeedDevelopment()
        {
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();

            var salt = "123#!";

            _ctx.AuthUsers.Add(new AuthUserEntity
            {
                Salt = salt,
                Username = "Silke",
                HashedPassword = _securityService.HashedPassword(
                    "123456", Encoding.ASCII.GetBytes(salt)),
            });
            _ctx.SaveChanges();
        }

        public void SeedProduction()
        {
            _ctx.Database.EnsureCreated();
        }
    }
}