using HBS.HairBySilke_2021.Security.Entities;
using Microsoft.EntityFrameworkCore;

namespace HBS.HairBySilke_2021.Security
{
    public class AuthDbContext: DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

        public DbSet<AuthUserEntity> AuthUsers { get; set; }
        
    }
}