using System;
using System.Linq;
using System.Text;
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

        public AuthUser? FindByUsernameAndPassword(string username, string hashedPassword)
        {
            var entity = _ctx.AuthUsers
                .FirstOrDefault(user =>
                    hashedPassword.Equals(user.HashedPassword) &&
                    username.Equals(user.Username));
            if (entity == null)
            {
                throw new NullReferenceException();
            };
            return new AuthUser
            {
                Id = entity.Id,
                Username = entity.Username
            };
        }

        public AuthUser FindUser(string username)
        {
            var entity = _ctx.AuthUsers
                .FirstOrDefault(user => username.Equals(user.Username));
            if (entity == null)
            {
                throw new NullReferenceException();
            };
            return new AuthUser
            {
                Id = entity.Id,
                Username = entity.Username,
                HashedPassword = entity.HashedPassword,
                Salt = Encoding.ASCII.GetBytes(entity.Salt)
            };
        }
    }
}