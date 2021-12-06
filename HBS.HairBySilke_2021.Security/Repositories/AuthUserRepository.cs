using System.Linq;
using HBS.HairBySilke_2021.Security.IRepositories;
using HBS.HairBySilke_2021.Security.Models;

namespace HBS.HairBySilke_2021.Security.Repositories
{
    public class AuthUserRepository : IAuthUserRepository
    {
        private readonly AuthDbContext _ctx;

        public AuthUserRepository(AuthDbContext ctx)
        {
            _ctx = ctx;
        }
        public AuthUser FindByUsernameAndPassword(string username, string hashedpassword)
        {
            var entity = _ctx.AuthUsers
                .FirstOrDefault(user =>
                    hashedpassword.Equals(user.HashedPassword) &&
                    username.Equals(user.Username));
            if (entity == null) return null;
            return new AuthUser
            {
                Id = entity.Id,
                Username = entity.Username
            };
        }
    }
}