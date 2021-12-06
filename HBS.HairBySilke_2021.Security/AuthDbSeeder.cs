using HBS.HairBySilke_2021.Security.Entities;

namespace HBS.HairBySilke_2021.Security
{
    public class AuthDbSeeder
    {
        private readonly AuthDbContext _ctx;

        public AuthDbSeeder(AuthDbContext ctx)
        {
            _ctx = ctx;
        }
        
        public void SeedDevelopment()
        {
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();

            _ctx.AuthUsers.Add(new AuthUserEntity
            {
                Username = "Silke",
                HashedPassword = "123456",
            });
            _ctx.SaveChanges();
        }

        public void SeedProduction()
        {
            _ctx.Database.EnsureCreated();
        }
    }
}